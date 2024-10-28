using degree_management.constracts.Abstractions;

namespace degree_management.domain.Entities;

public class Inventory : Entity<int>
{
    public int DegreeId { get; set; }
    public int WarehouseId { get; set; }
    public Degree Degree { get; set; }
    public Warehouse Warehouse { get; set; }
    public int Quantity { get; set; }
    public DateTime IssueDate { get; set; }
    public bool Status { get; set; }
    public string? Description { get; set; } = String.Empty;
}