using degree_management.constracts.Abstractions;

namespace degree_management.domain.Entities;

public class Major : Entity<int>
{
    public string Code { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; } = false;
    public string Description { get; set; } = String.Empty;
    public int FacultyId { get; set; }
    public Faculty? Faculty { get; set; }
    public List<StudentGraduated> StudentGraduateds { get; set; } = new List<StudentGraduated>();
}