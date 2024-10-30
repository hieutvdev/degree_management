namespace degree_management.application.Dtos.Requests.Warehouse;

public record CreateWarehouseRequest(string Name, string Code, bool Active, string Description);