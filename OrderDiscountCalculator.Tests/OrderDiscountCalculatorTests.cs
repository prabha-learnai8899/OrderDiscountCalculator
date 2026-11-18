using OrderDiscountCalculator.Factories;
using OrderDiscountCalculator.Interfaces;
using OrderDiscountCalculator.Models;
using OrderDiscountCalculator.Services;
using OrderDiscountCalculator.Strategies;

namespace OrderDiscountCalculator.Tests
{
    public class OrderDiscountCalculatorTests
    {
        private DiscountCalculatorService CreateCalculator()
        {
            var strategies = new List<IDiscountStrategy>
            {
                new RegularDiscountStrategy(),
                new PremiumDiscountStrategy(),
                new VipDiscountStrategy()
            };
            var factory = new DiscountStrategyFactory(strategies);
            return new DiscountCalculatorService(factory);
        }

        [Theory]
        [InlineData("Regular", 1000, 50, 950)]
        [InlineData("Premium", 1000, 100, 900)]
        [InlineData("VIP", 1000, 150, 850)]
        public void Calculate_ShouldApplyCorrectDiscount(
            string customerType,
            decimal amount,
            decimal expectedDiscount,
            decimal expectedFinal)
        {
            var calculator = CreateCalculator();

            var order = new Order(
                "Order_001", "Test Customer", customerType, amount);

            var result = calculator.Calculate(order);

            Assert.Equal(expectedDiscount, result.DiscountAmount);
            Assert.Equal(expectedFinal, result.FinalAmount);
        }

        [Fact]
        public void Calculate_ShouldRejectUnknownCustomerType()
        {
            var calculator = CreateCalculator();

            var order = new Order(
                "Order_001", "Test", "Student", 1000m);

            Assert.Throws<NotSupportedException>(
                () => calculator.Calculate(order));
        }

        [Fact]
        public void Calculate_ShouldRejectNegativeOrderAmount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Order(
                    "Order_001", "Test", "Regular", -100m));
        }

        [Fact]
        public void Calculate_ShouldHandleZeroOrderAmount()
        {
            var calculator = CreateCalculator();

            var order = new Order(
                "Order_001", "Test", "VIP", 0m);

            var result = calculator.Calculate(order);

            Assert.Equal(0m, result.DiscountAmount);
            Assert.Equal(0m, result.FinalAmount);
        }

    }
}
