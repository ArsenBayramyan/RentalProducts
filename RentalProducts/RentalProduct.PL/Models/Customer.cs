using RentalProducts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentalProducts.PL.Models
{
    [Table("Customer")]
    public class Customer : ICustomer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get ; set ; }
        public bool IsDeleted { get; set; }
    }
}
