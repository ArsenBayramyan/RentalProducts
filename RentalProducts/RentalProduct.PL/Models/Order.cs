using RentalProducts.Core.Calculator;
using RentalProducts.Core.CustomAttributes;
using RentalProducts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentalProducts.PL.Models
{
    public class Order : IModel
    {

        [Key]
        [SkipProperty]
        public int Id { get; set; }
        [Display(Name = "Type", Order = 1)]
        public CalculateType Type { get; set; }
        [Display(Name = "Days", Order = 2)]
        public int Days { get; set; }
        [Display(Name = "Price", Order = 3)]
        public decimal Price { get; set; }
        [Display(Name = "LoyaltyPoint", Order = 4)]
        public int LoyaltyPoint { get; set; }
        [SkipProperty]
        public bool IsDeleted { get; set; }
        [SkipProperty]
        public int CustomerId { get; set; }
        [SkipProperty]
        public int ProductId { get; set; }
    }
}
