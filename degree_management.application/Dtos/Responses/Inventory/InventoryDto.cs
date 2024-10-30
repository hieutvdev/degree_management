using degree_management.constracts.Abstractions;

namespace degree_management.application.Dtos.Responses.Inventory;

public class InventoryDto : Entity<int>
{
    public int Id { get; set; }
    public int DegreeId { get; set; }
    public int WarehouseId { get; set; }
    public int Quantity { get; set; }
    public DateTime IssueDate { get; set; }
    public bool Status { get; set; }
    public string? Description { get; set; } = String.Empty;
}