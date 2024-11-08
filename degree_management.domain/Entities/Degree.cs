using degree_management.constracts.Abstractions;

namespace degree_management.domain.Entities;

public class Degree : Entity<int>
{
    public int StudentGraduatedId { get; set; }
    public StudentGraduated? StudentGraduated { get; set; }
    public string Code { get; set; }
    
    public string RegNo { get; set; }
    public DateTime IssueDate { get; set; }
    public int Status { get; set; }
    public string? Description { get; set; } = String.Empty;
}