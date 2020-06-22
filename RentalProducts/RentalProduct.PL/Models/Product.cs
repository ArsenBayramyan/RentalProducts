using RentalProducts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalProducts.PL.Models
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string PhotoLink { get; set; }
        public bool IsDeleted { get; set; }
    }
}
