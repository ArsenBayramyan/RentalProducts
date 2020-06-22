using RentalProducts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalProducts.Core.Calculator
{
    public class CalculatorRegular : CalculatorBase
    {
        public override PricePoint Calculate(int days)
        {
            var price = Constants.OneTime;
            if (days > 2)
            {
                price += (days - 2) * Constants.Regular;
                price += 2 * Constants.Premium;
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
