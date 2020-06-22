using AutoMapper;
using RentalProducts.Core.Interfaces;
using RentalProducts.DAL.Contexts;
using RentalProducts.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalProducts.BLL.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Order> List => _context.Orders.Where(o=>o.IsDeleted==false);

        public bool Delete(int id)
        {
            var dbEntry = _context.Orders
           .FirstOrDefault(p => p.Id == id);
            if (dbEntry != null)
            {
                dbEntry.IsDeleted = true;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Save(Order entity)
        {
            if (entity.Id == 0)
            {
                _context.Add(entity);
            }
            else
            {
                var dbEntry = List.Where(o => o.Id == entity.Id)?.FirstOrDefault();
                if (dbEntry != null)
                {
                    dbEntry.Id = entity.Id;
                    dbEntry.Price = entity.Price;
                    dbEntry.Type = entity.Type;
                    dbEntry.LoyaltyPoint = entity.LoyaltyPoint;
                    dbEntry.IsDeleted = entity.IsDeleted;
                    dbEntry.CustomerId = entity.CustomerId;
                    dbEntry.Days = entity.Days;
                    dbEntry.ProductId = entity.ProductId;
                }
            }
            _context.SaveChanges();
        }
    }
}
