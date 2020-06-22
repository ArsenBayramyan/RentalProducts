using RentalProducts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalProducts.Core.Calculator
{
    public class CalculatorSpecialized : CalculatorBase
    {
        public override PricePoint Calculate(int days)
        {
            var price = Decimal.Zero;
            if (days > 3)
            {
                price += (days - 3) * Constants.Regular;
                price += 3 * Constants.Premium;
            }
            else
            {
                price += days * Constants.Premium;
            }

            return new PricePoint
            {
                Price = price,
                LoyaltyPoint = 1
            };
        }
    }
}
