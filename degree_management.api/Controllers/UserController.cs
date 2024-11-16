using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Auth;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.constracts.Specifications;
using degree_management.domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace degree_management.api.Controllers;

[Route("api/users")]
public class UserController : BaseController
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetList([FromQuery] SearchBaseModel searchBaseModel)
    {
        try
        {
            
            var usersQuery = _userManager.Users.Select(r => new UserResponseBase(
                r.Id, 
                r.UserName ?? "", 
                r.FullName, 
                r.Email ?? "", 
                r.Status, 
                r.Avatar, 
                r.CreatedAt
            ));

          
            var users = await usersQuery.ToListAsync();

        
            if (!string.IsNullOrEmpty(searchBaseModel.KeySearch))
            {
                var searchKey = searchBaseModel.KeySearch.ToLower();
                users = users
                    .Where(u => u.FullName.ToLower().Contains(searchKey) 
                                || u.UserName.ToLower().Contains(searchKey))
                    .ToList();
            }

         
            if (!string.IsNullOrEmpty(searchBaseModel.SortBy))
            {
                var sortBy = QueryableExtensions.GetProperty<UserResponseBase>(searchBaseModel.SortBy);
                users = searchBaseModel.IsOrder == true 
                    ? users.OrderBy(sortBy).ToList() 
                    : users.OrderByDescending(sortBy).ToList();
            }
            else
            {
                users = users.OrderByDescending(r => r.CreatedDate).ToList();
            }

            int pageIndex = searchBaseModel.PageIndex ?? 1;
            int pageSize = searchBaseModel.PageSize ?? 20;

            PaginatedResult<UserResponseBase> data = new PaginatedResult<UserResponseBase>(
                pageIndex, 
                pageSize, 
                users.Count,
                users.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
            );

            return Ok(data);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}