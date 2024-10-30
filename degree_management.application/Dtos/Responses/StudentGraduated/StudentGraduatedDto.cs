using degree_management.constracts.Abstractions;

namespace degree_management.application.Dtos.Responses.StudentGraduated;

public class StudentGraduatedDto : Entity<int>
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool Gender { get; set; }
    public DateTime GraduationYear { get; set; }
    public int MajorId { get; set; }
    public float GPA { get; set; }
    public int Honors { get; set; }
    public string ContactEmail { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;
}