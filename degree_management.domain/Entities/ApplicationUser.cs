using degree_management.constracts.Abstractions.Entities;
using Microsoft.AspNetCore.Identity;

namespace degree_management.domain.Entities;

public class ApplicationUser: IdentityUser, IEntity
{
    public string Avatar { get; set; } = default!;
    public int Status { get; set; }
    public string FullName { get; set; } = default!;
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}