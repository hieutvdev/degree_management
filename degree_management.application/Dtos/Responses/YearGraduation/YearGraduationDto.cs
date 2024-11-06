using degree_management.constracts.Abstractions;

namespace degree_management.application.Dtos.Responses.YearGraduation;

public class YearGraduationDto : Entity<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool? Active { get; set; } = false;
    public string? Description { get; set; }
}