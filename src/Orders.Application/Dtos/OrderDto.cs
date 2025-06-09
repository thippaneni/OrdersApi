namespace Orders.Application.Dtos
{
    public record OrderDto(Guid Id, string CustomerName, DateTime OrderDate, List<OrderItemDto> Items);
}
