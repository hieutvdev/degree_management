using degree_management.application.Dtos.Faculty;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.Faculty.Create;
using degree_management.application.UseCases.V1.Commands.Faculty.Delete;
using degree_management.application.UseCases.V1.Commands.Faculty.Update;
using degree_management.application.UseCases.V1.Queries.Faculty.GetFaculties;
using degree_management.application.UseCases.V1.Queries.Faculty.GetFaculty;
using degree_management.application.UseCases.V1.Queries.Faculty.GetSelectFaculites;
using degree_management.constracts.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace degree_management.api.Controllers;

[Route("api/Faculty")]
[ApiController]
public class FacultyController : ControllerBase
{
    private readonly IMediator _mediator;

    public FacultyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-list")]
    public async Task<IActionResult> GetList([FromQuery] PaginationRequest paginationRequest)
    {
        var result = await _mediator.Send(new GetFacultiesQuery(paginationRequest));
        return Ok(result);
    }   
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateFaculty([FromBody] CreateFacultyRequest req)
    {
        var result = await _mediator.Send(new CreateFacultyCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }   
    [HttpPut("update")]
    public async Task<IActionResult> UpdateFaculty([FromBody] UpdateFacultyRequest req)
    {
        var result = await _mediator.Send(new UpdateFacultyCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }    
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteFaculty([FromQuery] DeleteFacultyRequest req)
    {
        var result = await _mediator.Send(new DeleteFacultyCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

  
    [HttpGet("get-detail")]
    public async Task<IActionResult> GetDetail([FromQuery] int id)
    {
        var result = await _mediator.Send(new GetFacultyQuery(id));
        return Ok(result);
    }

    [HttpGet("get-select")]
    public async Task<IActionResult> GetSelect()
    {
        var result = await _mediator.Send(new GetSelectFaculitesQuery());
        return Ok(result);
    }
}