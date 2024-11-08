using degree_management.constracts.Abstractions;

namespace degree_management.application.Dtos.Responses.YearGraduation;

public class YearGraduationDto : Entity<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}