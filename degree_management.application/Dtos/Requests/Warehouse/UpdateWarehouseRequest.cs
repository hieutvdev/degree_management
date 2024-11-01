namespace degree_management.application.Dtos.Requests.Warehouse;

public record UpdateWarehouseRequest(int Id, string Name, string Code, bool Active, string? Description);