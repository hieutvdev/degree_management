using degree_management.constracts.Abstractions;

namespace degree_management.domain.Entities;

public class Faculty : Entity<int>
{
    public string Code { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; } = false;
    public string? Description { get; set; } = String.Empty;
    public List<Major> Majors { get; set; } = new List<Major>();
}