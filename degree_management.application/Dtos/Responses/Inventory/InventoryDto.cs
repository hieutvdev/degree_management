using degree_management.constracts.Abstractions;

namespace degree_management.application.Dtos.Responses.Inventory;

public class InventoryDto : Entity<int>
{
    public int Id { get; set; }
    public int DegreeTypeId { get; set; }
    public int WarehouseId { get; set; }
    public string WarehouseCode { get; set; }
    public string WarehouseName { get; set; }
    public string DegreeTypeCode { get; set; }
    public string DegreeTypeName { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; } = String.Empty;
}