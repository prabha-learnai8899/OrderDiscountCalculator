using OrderDiscountCalculator.Interfaces;

namespace OrderDiscountCalculator.Strategies
{
    public class PremiumDiscountStrategy : IDiscountStrategy
    {
        public string CustomerType => "Premium";

        public decimal DiscountRate => 0.10m;

        /// <summary>
        /// Calculates a discount equal to 10% of the specified amount for Premium customers.
        /// </summary>
        /// <param name="amount">The amount to calculate the discount for.</param>
        /// <returns>The discount amount.</returns>
        public decimal CalculateDiscount(decimal amount)
        {
            return amount * DiscountRate;
        }
    }
}
