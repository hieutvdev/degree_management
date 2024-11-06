using degree_management.application.Dtos.Requests.Specialization;
using degree_management.application.UseCases.V1.Commands.Specialization.Create;
using degree_management.application.UseCases.V1.Commands.Specialization.Delete;
using degree_management.application.UseCases.V1.Commands.Specialization.Update;
using degree_management.application.UseCases.V1.Queries.Faculty.GetSelectFaculites;
using degree_management.application.UseCases.V1.Queries.Specialization.GetSelectSpecializations;
using degree_management.application.UseCases.V1.Queries.Specialization.GetSpecialization;
using degree_management.application.UseCases.V1.Queries.Specialization.GetSpecializations;
using degree_management.constracts.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace degree_management.api.Controllers;

[Route("api/Specialization")]
[ApiController]
public class SpecializationController : ControllerBase
{
    private readonly IMediator _mediator;

    public SpecializationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-list")]
    public async Task<IActionResult> GetList([FromQuery] PaginationRequest paginationRequest)
    {
        var result = await _mediator.Send(new GetSpecializationsQuery(paginationRequest));
        return Ok(result);
    }   
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateSpecialization([FromBody] CreateSpecializationRequest req)
    {
        var result = await _mediator.Send(new CreateSpecializationCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }   
    [HttpPut("update")]
    public async Task<IActionResult> UpdateSpecialization([FromBody] UpdateSpecializationRequest req)
    {
        var result = await _mediator.Send(new UpdateSpecializationCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }    
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteSpecialization([FromQuery] DeleteSpecializationRequest req)
    {
        var result = await _mediator.Send(new DeleteSpecializationCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

  
    [HttpGet("get-detail")]
    public async Task<IActionResult> GetDetail([FromQuery] int id)
    {
        var result = await _mediator.Send(new GetSpecializationQuery(id));
        return Ok(result);
    }

    [HttpGet("get-select")]
    public async Task<IActionResult> GetSelect()
    {
        var result = await _mediator.Send(new GetSelectSpecializationsQuery());
        return Ok(result);
    }
}