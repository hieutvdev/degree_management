using degree_management.constracts.Abstractions;

namespace degree_management.domain.Entities;

public class StudentGraduated : Entity<int>
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string StudentCode { get; set; }
    public bool Gender { get; set; }
    public DateTime GraduationYear { get; set; }
    public int PeriodId { get; set; }
    public Period? Period { get; set; }
    public int MajorId { get; set; }
    public Major? Major { get; set; }
    public int DegreeTypeId { get; set; }
    public DegreeType? DegreeType { get; set; }
    public string? BirthPlace { get; set; }
    public string? ClassName { get; set; }
    public int? Cohort { get; set; }
    public int? Status { get; set; }
    public float GPA10 { get; set; }
    public float GPA4 { get; set; }
    public int Honors { get; set; }
    public string? ContactEmail { get; set; } = String.Empty;
    public string? PhoneNumber { get; set; } = String.Empty;
}