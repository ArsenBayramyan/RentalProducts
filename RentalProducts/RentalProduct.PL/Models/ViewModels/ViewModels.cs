﻿using RentalProducts.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalProduct.PL.Models.ViewModels
{
    public class ViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string PhotoLink { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
