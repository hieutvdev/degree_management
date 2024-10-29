using degree_management.constracts.Abstractions;

namespace degree_management.application.Dtos.Responses.DegreeType;

public class DegreeTypeDto : Entity<int>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; } = false;
    public float Duration { get; set; }
    public string Descripion { get; set; }
    public int Level { get; set; }
}