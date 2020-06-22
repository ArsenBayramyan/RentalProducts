using RentalProducts.Core.Models;

namespace RentalProducts.Core.Calculator
{
    public class CalculatorHeavy : CalculatorBase
    {
        public override PricePoint Calculate(int days)
        {
            var price = Constants.OneTime;
            price += days * Constants.Premium;

            return new PricePoint
            {
                Price = price,
                LoyaltyPoint = 2
            };
        }
    }
}
