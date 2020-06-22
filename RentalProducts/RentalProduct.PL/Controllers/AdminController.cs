using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalProducts.BLL.Repository;
using RentalProducts.DAL.Contexts;
using Microsoft.AspNetCore.Authorization;
using RentalProduct.PL.Helper;
using System;

namespace RentalProduct.PL.Controllers
{
    [Authorize]
    public class AdminController:Controller
    {
        UnitOfWorkRepository _uow;
        ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _uow = new UnitOfWorkRepository(context);
            _context = context;
        }
        public IActionResult Index()
        {
            try
            {
                RentalProducts.DAL.Models.ViewModels.ViewModels viewModel = new RentalProducts.DAL.Models.ViewModels.ViewModels
                {
                    Products = _uow.productRepository.List,
                    Customers = _uow.customerRepository.List,
                    Orders = _uow.orderRepository.List
                };
                EventLogger.WriteLog("Get Products and Orders Lists",_context);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, _context);
                return BadRequest();
            }
        }
    }
}
