namespace degree_management.application.Dtos.Requests.Inventory;

public record UpdateInventoryRequest(int Id, int DegreeId, int WarehouseId, int Quantity, DateTime IssueDate, bool Status, string? Description);