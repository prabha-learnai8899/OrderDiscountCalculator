namespace OrderDiscountCalculator.Interfaces
{
    public interface IDiscountStrategy
    {
        string CustomerType { get; }

        decimal DiscountRate { get; }

        decimal CalculateDiscount(decimal amount);
    }
}
