using degree_management.constracts.Abstractions;

namespace degree_management.domain.Entities;

public class DegreeType : Entity<int>
{
    public string Code { get; set; }
    public string Name { get; set; }
    public float Duration { get; set; }
    public string? Description { get; set; } = string.Empty;
    public int Level { get; set; }
    public int SpecializationId { get; set; }
    public Specialization? Specialization { get; set; }
}