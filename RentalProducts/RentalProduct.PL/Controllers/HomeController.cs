using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalProduct.PL.Helper;
using RentalProduct.PL.Models.ViewModels;
using RentalProducts.BLL.Repository;
using RentalProducts.Core.Calculator;
using RentalProducts.Core.Factories;
using RentalProducts.Core.Helpers;
using RentalProducts.DAL.Contexts;
using RentalProducts.PL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace RentalProduct.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UnitOfWorkRepository _uow;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
            _uow = new UnitOfWorkRepository(context);
        }

        public IActionResult Index()
        {
            try
            {
                RentalProducts.DAL.Models.ViewModels.ViewModels viewModel = new RentalProducts.DAL.Models.ViewModels.ViewModels
                {
                    Products = _uow.productRepository.List,
                    Customers = _uow.customerRepository.List
                };
                EventLogger.WriteLog("Get Products List", _context);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, _context);
                return BadRequest();
            }
        }

        public byte[] Report(string modelName)
        {
            try
            {
                var customer = _uow.customerRepository.List.Where(r => r.Name == modelName)?.First();
                if (customer != null)
                {
                    var list = _uow.orderRepository.List.Where(r => r.CustomerId == customer.Id).ToList();
                    var arr = ExcelHelper.ExportToExcel<RentalProducts.DAL.Models.Order>(list, $"{modelName}_Report");
                    EventLogger.WriteLog($"Get {customer.Name}'s Report", _context);
                    return arr;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, _context);
                return null;
            }
        }
    }
}
