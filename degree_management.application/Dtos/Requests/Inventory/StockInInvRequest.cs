namespace degree_management.application.Dtos.Requests.Inventory;

public record StockInInvRequest(int WarehouseId, int DegreeTypeId, int Quantity, string? Description);