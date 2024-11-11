using degree_management.constracts.Abstractions;

namespace degree_management.domain.Entities;

public class Inventory : Entity<int>
{
    public int DegreeTypeId { get; set; }
    public int WarehouseId { get; set; }
    public DegreeType DegreeType { get; set; }
    public Warehouse Warehouse { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; } = String.Empty;
}