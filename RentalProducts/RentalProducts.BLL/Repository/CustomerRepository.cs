using RentalProducts.Core.Interfaces;
using RentalProducts.DAL.Contexts;
using RentalProducts.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalProducts.BLL.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> List => _context.Customers;

        public bool Delete(int id)
        {
            var dbEntry = _context.Customers
            .FirstOrDefault(p => p.Id == id);
            if (dbEntry != null)
            {
                dbEntry.IsDeleted = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Save(Customer entity)
        {
            if (entity.Id == 0)
            {
                _context.Add(entity);
            }
            else
            {
                var dbEntry = _context.Customers
                .FirstOrDefault(p => p.Id == entity.Id);
            }
            _context.SaveChanges();
        }
    }
}
