using degree_management.constracts.Abstractions;

namespace degree_management.domain.Entities;

public class Period : Entity<int>
{
    public string? Name { get; set; }
    public DateTime? StartDate { get; set; } 
    public DateTime? EndDate { get; set; }
    public bool? Active { get; set; } = false;
    public string? Description { get; set; }
    public int YearGraduationId { get; set; }
    public YearGraduation? YearGraduation { get; set; }
}