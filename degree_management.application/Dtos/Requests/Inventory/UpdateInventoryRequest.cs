namespace degree_management.application.Dtos.Requests.Inventory;

public record UpdateInventoryRequest(int Id, int WarehouseId, int DegreeTypeId, int Quantity,  string? Description);