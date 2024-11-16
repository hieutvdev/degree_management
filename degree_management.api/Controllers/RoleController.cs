
using degree_management.application.Dtos.Requests.Role;
using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Role;
using degree_management.constracts.Pagination;
using degree_management.constracts.Specifications;
using degree_management.domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace degree_management.api.Controllers;

// [Authorize(Roles = "ADMIN")]
[ApiController]
[Route("api/roles")]
public class RoleController : Controller
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public RoleController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        _userManager = userManager;
    }



    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateRoleRequestDto model)
    {
        var applicationRole = new ApplicationRole
        {
            Name = model.Name.ToUpper(),
            Description = model.Description,
            Status = model.Status,
        };
        var res = (await _roleManager.CreateAsync(applicationRole)).Succeeded == true;
        return Ok(new ResponseBase(null, Message: res ? "Success" : "Failure", IsSuccess: res));
    }

    [HttpGet("get-list")]
    public async Task<IActionResult> GetList([FromQuery] SearchBaseModel model)
    {
        var rolesQuery = _roleManager.Roles.Select(r => new RoleResponseBase(
            r.Id, 
            r.Name ?? "",
            r.Description ?? "",
            r.Status
            
        ));

          
        var roles = await rolesQuery.ToListAsync();

        
        if (!string.IsNullOrEmpty(model.KeySearch))
        {
            var searchKey = model.KeySearch.ToLower();
            roles = roles
                .Where(u => u.Name.ToLower().Contains(searchKey) 
                            || u.Description.ToLower().Contains(searchKey))
                .ToList();
        }

         
        if (!string.IsNullOrEmpty(model.SortBy))
        {
            var sortBy = QueryableExtensions.GetProperty<RoleResponseBase>(model.SortBy);
            roles = model.IsOrder == true 
                ? roles.OrderBy(sortBy).ToList() 
                : roles.OrderByDescending(sortBy).ToList();
        }
        else
        {
                
            roles = roles.OrderByDescending(r => r.Id).ToList();
        }

        int pageIndex = model.PageIndex ?? 1;
        int pageSize = model.PageSize ?? 20;

        PaginatedResult<RoleResponseBase> data = new PaginatedResult<RoleResponseBase>(
            pageIndex, 
            pageSize, 
            roles.Count,
            roles.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
        );

        return Ok(data);
    }

    [HttpGet("detail")]
    public async Task<IActionResult> Get([FromQuery] string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role == null)
        {
            return BadRequest(new ResponseBase(IsSuccess: false, Data: null, Message: "Get Role Failure"));
        }

        return Ok(new ResponseBase(role, Message: "Success", IsSuccess: true));
    }
    
    
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateRoleRequestDto model)
    {
        var role = await _roleManager.FindByIdAsync(model.Id);
        if (role == null)
        {
            return BadRequest(new ResponseBase(IsSuccess: false, Data: null, Message: "Get Role Failure"));
        }

        role.Name = model.Name.ToUpper();
        role.Description = model.Description;
        role.Status = model.Status;
        var isSuccess = (await _roleManager.UpdateAsync(role)).Succeeded == true;

        return Ok(new ResponseBase(role, Message:isSuccess ? "Success" : "Failure", IsSuccess: isSuccess));
    }


    [HttpPost("assign-role")]
    public async Task<IActionResult> AssignRole([FromBody] AssignRoleRequestDto model)
    {
        var user = await _userManager.FindByIdAsync(model.UserId);
        if (user == null)
        {
            return BadRequest(new ResponseBase(null, IsSuccess: false, Message: "User not found"));
        }

        // Get the current roles of the user
        var currentRoles = await _userManager.GetRolesAsync(user);

        // Determine roles to remove (present in currentRoles but not in model.RoleNames)
        var rolesToRemove = currentRoles.Where(r => !model.RoleNames.Contains(r)).ToList();

        // Determine roles to add (present in model.RoleNames but not in currentRoles)
        var rolesToAdd = model.RoleNames.Where(r => !currentRoles.Contains(r)).ToList();

        // Remove roles that are no longer required
        if (rolesToRemove.Any())
        {
            var removeResult = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
            if (!removeResult.Succeeded)
            {
                return BadRequest(new ResponseBase(null, IsSuccess: false, Message: "Failed to remove roles"));
            }
        }

        if (rolesToAdd.Any())
        {
            var addResult = await _userManager.AddToRolesAsync(user, rolesToAdd);
            if (!addResult.Succeeded)
            {
                return BadRequest(new ResponseBase(null, IsSuccess: false, Message: "Failed to add roles"));
            }
        }

        return Ok(new ResponseBase(null, IsSuccess: true, Message: "Roles updated successfully"));
    }

    
}