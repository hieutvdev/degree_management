namespace degree_management.application.Dtos.Requests.Inventory;

public record StockOutRequest(int WarehouseId, int DegreeTypeId, int Quantity, string? Description);