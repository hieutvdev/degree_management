using degree_management.constracts.Abstractions;

namespace degree_management.application.Dtos.Responses.Warehouse;

public class WarehouseDto : Entity<int>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; } = String.Empty;
}