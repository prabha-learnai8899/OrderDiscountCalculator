namespace OrderDiscountCalculator.Models
{
    public class Order
    {
        public string OrderId { get; }
        public string CustomerName { get; }
        public string CustomerType { get; }
        public decimal OrderAmount { get; }

        public Order(
            string orderId,
            string customerName,
            string customerType,
            decimal orderAmount)
        {
            if (string.IsNullOrWhiteSpace(orderId))
                throw new ArgumentException("Order ID is required.");

            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Customer name is required.");

            if (string.IsNullOrWhiteSpace(customerType))
                throw new ArgumentException("Customer type is required.");

            if (orderAmount < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(orderAmount),
                    "Order amount cannot be negative.");

            OrderId = orderId.Trim();
            CustomerName = customerName.Trim();
            CustomerType = customerType.Trim();
            OrderAmount = orderAmount;
        }
    }
}
