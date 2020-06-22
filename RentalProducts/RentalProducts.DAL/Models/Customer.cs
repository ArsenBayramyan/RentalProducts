using RentalProducts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentalProducts.DAL.Models
{
    public class Customer : ICustomer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get ; set ; }
        public bool IsDeleted { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
