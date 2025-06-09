public class BaseEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? LastUpdatedBy { get; set; }
    public DateTime LastUpdatedAt { get; set; }
}