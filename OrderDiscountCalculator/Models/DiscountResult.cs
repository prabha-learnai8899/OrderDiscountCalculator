namespace OrderDiscountCalculator.Models
{
    public class DiscountResult
    {
        public string OrderId { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public string CustomerType { get; set; } = "";
        public decimal OriginalAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }
    }
}
