using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalProduct.PL.Helper;
using RentalProduct.PL.Models.ViewModels;
using RentalProducts.BLL.Repository;
using RentalProducts.Core.Calculator;
using RentalProducts.Core.Factories;
using RentalProducts.Core.Interfaces;
using RentalProducts.DAL.Contexts;
using RentalProducts.PL.Models;

namespace RentalProduct.PL.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private ApplicationDbContext _context;
        private UnitOfWorkRepository _uow;
        private IProduct _product;
        private ICustomer _customer;
        public OrdersController(ApplicationDbContext context, IProduct product,ICustomer customer)
        {
            _uow = new UnitOfWorkRepository(context);
            _product = product;
            _customer = customer;
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            try
            {
                var customer = new Customer { Id = _customer.Id };
                var product = new Product { Id = _product.Id };
                var model = new RentalProducts.DAL.Models.ViewModels.ViewModels
                {
                    Orders = _uow.orderRepository.List.Where(o => o.CustomerId == _customer.Id),
                    Customers = _uow.customerRepository.List.Where(c => c.Id == customer.Id),
                    Products = _uow.productRepository.List
                };
                EventLogger.WriteLog("Get Orders List", _context);
                return View(model);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, _context);
                return BadRequest();
            }
            
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Create(int id)
        {
            _product.Id = id;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderCustomerViewModel order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pricePoint = CalculatorCreator.Create((CalculateType)order.OrderType).Calculate(order.Days);
                    var customer = _uow.customerRepository.List.Where(r => r.Name == order.CustomerName)?.FirstOrDefault();
                    if (customer == null)
                    {
                        _uow.customerRepository.Save(new RentalProducts.DAL.Models.Customer { Name = order.CustomerName });
                        var custId = _uow.customerRepository.List.Where(r => r.Name == order.CustomerName)?.FirstOrDefault();
                        _customer.Id = custId.Id;
                    }
                    else
                    {
                        _customer.Id = customer.Id;
                    }

                    var orderEntity = new RentalProducts.DAL.Models.Order
                    {
                        CustomerId = _customer.Id,
                        ProductId = _product.Id,
                        Price = pricePoint.Price,
                        Days = order.Days,
                        LoyaltyPoint = pricePoint.LoyaltyPoint,
                        Type = order.OrderType
                    };

                    _uow.orderRepository.Save(orderEntity);
                    EventLogger.WriteLog($"Create {customer.Name}'s Order", _context);
                    return Redirect("/Orders/Index");
                }
                return View(order);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, _context);
                return BadRequest();
            }
        }

        [AllowAnonymous]
        public IActionResult Delete(int id)
        {
            try
            {
                var order = _uow.orderRepository.List.Where(o => o.Id == id).FirstOrDefault();
                var deletedOrder = _uow.orderRepository.Delete(id);
                EventLogger.WriteLog($"Delete {order.Type} order", _context);
                return Redirect("/Admin/Index");
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex,_context);
                return BadRequest();
            }
        }
    }
}
