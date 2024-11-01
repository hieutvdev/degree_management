using degree_management.application.Dtos.Requests.Degree;
using degree_management.application.UseCases.V1.Commands.Degree.Create;
using degree_management.application.UseCases.V1.Commands.Degree.Delete;
using degree_management.application.UseCases.V1.Commands.Degree.Update;
using degree_management.application.UseCases.V1.Queries.Degree.GetDegree;
using degree_management.application.UseCases.V1.Queries.Degree.GetDegrees;
using degree_management.application.UseCases.V1.Queries.Degree.GetSelectDegrees;
using degree_management.constracts.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace degree_management.api.Controllers;

[Route("api/Degree")]
[ApiController]
public class DegreeController : ControllerBase
{
    private readonly IMediator _mediator;

    public DegreeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-list")]
    public async Task<IActionResult> GetList([FromQuery] PaginationRequest req)
    {
        var result = await _mediator.Send(new GetDegreesQuery(req));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateDegreeRequest req)
    {
        var result = await _mediator.Send(new CreateDegreeCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateDegreeRequest req)
    {
        var result = await _mediator.Send(new UpdateDegreeCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] DeleteDegreeRequest req)
    {
        var result = await _mediator.Send(new DeleteDegreeComand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("get-detail")]
    public async Task<IActionResult> GetDetail([FromQuery] int id)
    {
        var result = await _mediator.Send(new GetDegreeQuery(id));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpGet("get-select")]
    public async Task<IActionResult> GetSelect()
    {
        var result = await _mediator.Send(new GetSelectDegreesQuery());
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}