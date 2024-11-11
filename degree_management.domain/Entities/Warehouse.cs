using degree_management.constracts.Abstractions;

namespace degree_management.domain.Entities;

public class Warehouse : Entity<int>
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; } = String.Empty;
}