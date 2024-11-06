using degree_management.constracts.Abstractions;

namespace degree_management.application.Dtos.Responses.StudentGraduated;

public class StudentGraduatedDto : Entity<int>
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool Gender { get; set; }
    public DateTime GraduationYear { get; set; }
    public int SpecializationId { get; set; }
    public int PeriodId { get; set; }
    public string SpecializationName { get; set; }
    public string? BirthPlace { get; set; }
    public string? ClassName { get; set; }
    public int? Cohort { get; set; }
    public int? Status { get; set; }
    public float GPA10 { get; set; }
    public float GPA4 { get; set; }
    public int Honors { get; set; }
    public string ContactEmail { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;
}