using OrderDiscountCalculator.Interfaces;

namespace OrderDiscountCalculator.Factories
{
    public class DiscountStrategyFactory
    {
        private readonly Dictionary<string, IDiscountStrategy> _strategies;
        public DiscountStrategyFactory(IEnumerable<IDiscountStrategy> strategies)
        {
            _strategies = new Dictionary<string, IDiscountStrategy>(StringComparer.OrdinalIgnoreCase);

            foreach (var strategy in strategies)
            {
                if (strategy == null)
                    throw new ArgumentException("Strategy cannot be null.");

                if (string.IsNullOrWhiteSpace(strategy.CustomerType))
                    throw new ArgumentException("Customer type is required.");

                if (!_strategies.TryAdd(strategy.CustomerType.Trim(), strategy))
                {
                    throw new ArgumentException($"Duplicate strategy: {strategy.CustomerType}");
                }
            }
        }

        public IDiscountStrategy GetStrategy(string customerType)
        {
            if (string.IsNullOrWhiteSpace(customerType))
                throw new ArgumentException("Customer type is required.");

            if (_strategies.TryGetValue(customerType.Trim(), out var strategy))
            {
                return strategy;
            }

            throw new NotSupportedException($"No discount strategy found for {customerType}");
        }
    }
}