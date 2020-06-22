using RentalProducts.Core.Calculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalProducts.Core.Factories
{
    public static class CalculatorCreator
    {
        public static CalculatorBase Create(CalculateType type)
        {
            switch (type)
            {
                case CalculateType.Heavy:
                    return new CalculatorHeavy();
                case CalculateType.Regular:
                    return new CalculatorRegular();
                case CalculateType.Specialized:
                    return new CalculatorSpecialized();
                default:
                   throw new Exception("The type does not supported !");
            }
        }
    }
}
