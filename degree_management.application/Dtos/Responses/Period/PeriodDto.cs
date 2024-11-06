using degree_management.constracts.Abstractions;

namespace degree_management.application.Dtos.Responses.Period;

public class PeriodDto : Entity<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? StartDate { get; set; } 
    public DateTime? EndDate { get; set; }
    public bool? Active { get; set; } = false;
    public string? Description { get; set; }
    public string? YearGraduationName { get; set; }
}