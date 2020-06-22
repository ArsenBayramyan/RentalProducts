using RentalProducts.DAL.Models;
using RentalProducts.Core.Interfaces;
using RentalProducts.DAL.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace RentalProducts.BLL.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Product> List=> _context.Products.Where(p => p.IsDeleted == false);

        public bool Delete(int id)
        {
            var dbEntry = _context.Products
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

        public void Save(Product entity)
        {
            if (entity.Id == 0)
            {
                _context.Add(entity);
            }
            else
            {
                var dbEntry = List.Where(p => p.Id == entity.Id)?.FirstOrDefault();
                if (dbEntry != null)
                {
                    dbEntry.Id = entity.Id;
                    dbEntry.Name = entity.Name;
                    dbEntry.Description = entity.Description;
                    dbEntry.PhotoLink = entity.PhotoLink;
                    dbEntry.Orders = entity.Orders;
                }
            }
            _context.SaveChanges();
        }


    }
}
