namespace degree_management.application.Dtos.Requests.Inventory;

public record CreateInventoryRequest(int DegreeId, int WarehouseId, int Quantity, DateTime IssueDate, bool Status, string Description);