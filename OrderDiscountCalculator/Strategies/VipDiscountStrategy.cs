using OrderDiscountCalculator.Interfaces;

namespace OrderDiscountCalculator.Strategies
{
    public class VipDiscountStrategy : IDiscountStrategy
    {
        public string CustomerType => "Vip";

        public decimal DiscountRate => 0.15m;

        /// <summary>
        /// Calculates a discount equal to 15% of the specified amount for Vip customers.
        /// </summary>
        /// <param name="amount">The amount to calculate the discount for.</param>
        /// <returns>The discount amount.</returns>
        public decimal CalculateDiscount(decimal amount)
        {
            return amount * DiscountRate;
        }
    }
}
