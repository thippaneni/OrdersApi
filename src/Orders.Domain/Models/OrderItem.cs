namespace Orders.Domain.Models
{
    public class OrderItem
    {
        public string ProductId { get; set; } = default!;
        public int Quantity { get; set; }
    }
}
