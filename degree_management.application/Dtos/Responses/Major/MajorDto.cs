using degree_management.constracts.Abstractions;

namespace degree_management.application.Dtos.Responses.Major;

public class MajorDto : Entity<int>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } = String.Empty;
    public int FacultyId { get; set; }
    public string FacultyName { get; set; }
}