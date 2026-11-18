using OrderDiscountCalculator.Factories;
using OrderDiscountCalculator.Models;

namespace OrderDiscountCalculator.Services
{
    public class DiscountCalculatorService
    {
        private readonly DiscountStrategyFactory _factory;

        public DiscountCalculatorService(DiscountStrategyFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public DiscountResult Calculate(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            // Get appropriate discount strategy
            var strategy = _factory.GetStrategy(order.CustomerType);

            // Calculate discount
            var discountAmount = decimal.Round(strategy.CalculateDiscount(order.OrderAmount), 2, MidpointRounding.AwayFromZero);

            // Calculate final amount
            var finalAmount = order.OrderAmount - discountAmount;

            return new DiscountResult
            {
                OrderId = order.OrderId,
                CustomerName = order.CustomerName,
                CustomerType = order.CustomerType,
                OriginalAmount = order.OrderAmount,
                DiscountPercentage = decimal.Round(order.OrderAmount == 0 ? 0 : discountAmount / order.OrderAmount * 100, 2, MidpointRounding.AwayFromZero),
                DiscountAmount = discountAmount,
                FinalAmount = finalAmount
            };
        }
    }
}
