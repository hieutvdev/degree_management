namespace degree_management.application.Dtos.Requests.Inventory;

public record UpdateInventoryRequest(int Id, int DegreeTypeId, int WarehouseId, int Quantity,  string? Description);