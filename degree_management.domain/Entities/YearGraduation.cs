using degree_management.constracts.Abstractions;

namespace degree_management.domain.Entities;

public class YearGraduation : Entity<int>
{
    public string? Name { get; set; }
    public bool? Active { get; set; } = false;
    public string? Description { get; set; }
    public List<Period> Periods { get; set; } = new List<Period>();
}