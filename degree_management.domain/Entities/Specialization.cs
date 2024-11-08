using degree_management.constracts.Abstractions;

namespace degree_management.domain.Entities;

public class Specialization : Entity<int>
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; } = String.Empty;
    public DegreeType DegreeType { get; set; }
    public int MajorId { get; set; }
    public Major? Major { get; set; }
    public List<StudentGraduated> StudentGraduateds { get; set; } = new List<StudentGraduated>();
}