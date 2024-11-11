namespace degree_management.application.Dtos.Requests.Inventory;

public record CreateInventoryRequest( int WarehouseId, int DegreeTypeId, int Quantity,  string? Description);