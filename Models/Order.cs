public class Order : BaseEntity
{
    public int CustomerId { get; set; }
    public string OrderNumber { get; set; } = default!;
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public DateTime? ShippedDate { get; set; }
    public decimal TotalAmount { get; set; }
}