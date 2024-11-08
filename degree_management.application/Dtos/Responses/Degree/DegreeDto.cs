using degree_management.constracts.Abstractions;

namespace degree_management.application.Dtos.Responses.Degree;

public class DegreeDto : Entity<int>
{
    public int Id { get; set; }
    public int StundentId { get; set; }
    public string StundentCode { get; set; }
    public string StudentName { get; set; }
    public string Code { get; set; }
    public string RegNo { get; set; }
    public int Status { get; set; }
    public string? Description { get; set; } = String.Empty;
}