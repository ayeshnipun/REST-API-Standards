public class OrderDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string OrderNumber { get; set; } = default!;
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public DateTime? ShippedDate { get; set; }
    public decimal TotalAmount { get; set; }
}