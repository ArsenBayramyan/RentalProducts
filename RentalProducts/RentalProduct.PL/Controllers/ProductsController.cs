using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalProduct.PL.Helper;
using RentalProducts.BLL.Repository;
using RentalProducts.DAL.Contexts;
using RentalProducts.DAL.Models;

namespace RentalProduct.PL.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UnitOfWorkRepository _uow;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
            _uow = new UnitOfWorkRepository(context);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return Redirect("/Admin/Index");
                }
                EventLogger.WriteLog($"Create {product.Name} Product", _context);
                return View(product);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, _context);
                return BadRequest();
            }
            
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            try
            {
                var product = _uow.productRepository.List.Where(p => p.Id == id).FirstOrDefault();
                if (product == null)
                {
                    EventLogger.WriteLog("Product not found", _context);
                    return NotFound();
                }
                EventLogger.WriteLog($"Get {product.Name} Product for Edit", _context);
                return View(product);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, _context);
                return BadRequest();
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _uow.productRepository.Save(product);
                    TempData["message"] = $"{product.Name} has been saved";
                    EventLogger.WriteLog($"Edit {product.Name} product", _context);
                    return Redirect("/Admin/Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex,_context);
                return BadRequest();
            }
            
        }

        [AllowAnonymous]
        public IActionResult Delete(int id)
        {
            try
            {
                var product = _uow.productRepository.List.Where(p => p.Id == id).First();
                var deletedProduct = _uow.productRepository.Delete(id);
                EventLogger.WriteLog($"{product.Name} product deleted",_context);
                return Redirect("/Admin/Index");
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, _context);
                return BadRequest();
            }
            
        }
    }
}
