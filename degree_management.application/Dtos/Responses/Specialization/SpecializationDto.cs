using degree_management.constracts.Abstractions;

namespace degree_management.application.Dtos.Responses.Specialization;

public class SpecializationDto : Entity<int>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; } = String.Empty;
    public string? MajorName { get; set; } = String.Empty;
}