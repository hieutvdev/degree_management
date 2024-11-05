namespace degree_management.application.Dtos.Requests.Inventory;

public record CreateInventoryRequest(int DegreeTypeId, int WarehouseId, int Quantity,  string? Description);