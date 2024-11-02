using degree_management.constracts.Abstractions.Entities;
using Microsoft.AspNetCore.Identity;

namespace degree_management.domain.Entities;

public class ApplicationRole : IdentityRole, IEntity
{
    public string Description { get; set; } = default!;
    public int Status { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}