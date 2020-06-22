using RentalProducts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalProducts.Core.Calculator
{
    public abstract class CalculatorBase
    {
        public abstract PricePoint Calculate(int days);
    }
}
