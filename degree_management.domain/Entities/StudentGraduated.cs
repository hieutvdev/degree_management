using degree_management.constracts.Abstractions;

namespace degree_management.domain.Entities;

public class StudentGraduated : Entity<int>
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    
    public string StudentCode { get; set; }
    public bool Gender { get; set; }
    public DateTime GraduationYear { get; set; }
    public int MajorId { get; set; }
    public Major? Major { get; set; }
    public float GPA { get; set; }
    public int Honors { get; set; }
    public string? ContactEmail { get; set; } = String.Empty;
    public string? PhoneNumber { get; set; } = String.Empty;
}