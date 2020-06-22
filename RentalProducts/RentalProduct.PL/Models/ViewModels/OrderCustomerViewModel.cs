using RentalProducts.Core.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalProduct.PL.Models.ViewModels
{
    public class OrderCustomerViewModel
    {
        public string CustomerName { get; set; }
        public CalculateType OrderType { get; set; }
        public int Days { get; set; }
    }
}
