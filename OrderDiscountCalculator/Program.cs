using OrderDiscountCalculator.Factories;
using OrderDiscountCalculator.Interfaces;
using OrderDiscountCalculator.Models;
using OrderDiscountCalculator.Services;
using OrderDiscountCalculator.Strategies;



// Register discount strategies
var strategies = new List<IDiscountStrategy>
{
    new RegularDiscountStrategy(),
    new PremiumDiscountStrategy(),
    new VipDiscountStrategy()
};

// Create factory
var factory = new DiscountStrategyFactory(strategies);

// In a production application, I would register all strategies using .NET Dependency Injection and inject IEnumerable<IDiscountStrategy> into the factory.
var calculator = new DiscountCalculatorService(factory);

// Sample orders
var orders = new List<Order>
{
    new Order("Order_001", "John", "Regular", 1000),
    new Order("Order_002", "Rahul", "Premium", 2500),
    new Order("Order_003", "Sravan", "VIP", 5000),
    new Order("Order_004", "Krishna", "Premium", 5650.25m)

};

Console.WriteLine("ORDER DISCOUNT CALCULATOR");
Console.WriteLine(new string('-', 85));

foreach (var order in orders)
{
    try
    {
        var result = calculator.Calculate(order);

        Console.WriteLine($"Order ID       : {result.OrderId}");
        Console.WriteLine($"Customer       : {result.CustomerName}");
        Console.WriteLine($"Customer Type  : {result.CustomerType}");
        Console.WriteLine($"Order Amount   : {result.OriginalAmount:N2}");
        Console.WriteLine($"Discount       : {result.DiscountPercentage}%");
        Console.WriteLine($"Discount Amount: {result.DiscountAmount:N2}");
        Console.WriteLine($"Final Amount   : {result.FinalAmount:N2}");

        Console.WriteLine(new string('-', 85));

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

Console.ReadKey();
