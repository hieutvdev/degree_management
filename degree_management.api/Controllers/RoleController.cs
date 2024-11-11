
using degree_management.domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace degree_management.api.Controllers;
[Route("v1/api")]
public class RoleController : BaseController
{
    private readonly RoleManager<ApplicationRole> _roleManager;

    public RoleController(RoleManager<ApplicationRole> roleManager)
    {
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
    }
    
    
}