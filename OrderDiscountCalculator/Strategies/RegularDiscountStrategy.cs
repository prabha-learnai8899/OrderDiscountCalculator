using OrderDiscountCalculator.Interfaces;

namespace OrderDiscountCalculator.Strategies
{
    public class RegularDiscountStrategy : IDiscountStrategy
    {
        public string CustomerType => "Regular";

        public decimal DiscountRate => 0.05m;

        /// <summary>
        /// Calculates a discount equal to 5% of the specified amount for Regular customers.
        /// </summary>
        /// <param name="amount">The amount to calculate the discount for.</param>
        /// <returns>The discount amount.</returns>
        public decimal CalculateDiscount(decimal amount)
        {
            return amount * DiscountRate;
        }
    }
}
