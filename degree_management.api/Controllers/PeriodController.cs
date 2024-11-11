using degree_management.application.Dtos.Requests.Period;
using degree_management.application.UseCases.V1.Commands.Period.Create;
using degree_management.application.UseCases.V1.Commands.Period.Delete;
using degree_management.application.UseCases.V1.Commands.Period.Update;
using degree_management.application.UseCases.V1.Queries.Faculty.GetSelectFaculites;
using degree_management.application.UseCases.V1.Queries.Period.GetPeriod;
using degree_management.application.UseCases.V1.Queries.Period.GetPeriods;
using degree_management.constracts.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace degree_management.api.Controllers;

[Route("api/Period")]
[ApiController]
public class PeriodController : ControllerBase
{
    private readonly IMediator _mediator;

    public PeriodController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-list")]
    public async Task<IActionResult> GetList([FromQuery] PaginationRequest paginationRequest)
    {
        var result = await _mediator.Send(new GetPeriodsQuery(paginationRequest));
        return Ok(result);
    }   
    
    [HttpPost("create")]
    public async Task<IActionResult> CreatePeriod([FromBody] CreatePeriodRequest req)
    {
        var result = await _mediator.Send(new CreatePeriodCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }   
    [HttpPut("update")]
    public async Task<IActionResult> UpdatePeriod([FromBody] UpdatePeriodRequest req)
    {
        var result = await _mediator.Send(new UpdatePeriodCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }    
    [HttpDelete("delete")]
    public async Task<IActionResult> DeletePeriod([FromQuery] DeletePeriodRequest req)
    {
        var result = await _mediator.Send(new DeletePeriodCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

  
    [HttpGet("get-detail")]
    public async Task<IActionResult> GetDetail([FromQuery] int id)
    {
        var result = await _mediator.Send(new GetPeriodQuery(id));
        return Ok(result);
    }

    [HttpGet("get-select")]
    public async Task<IActionResult> GetSelect()
    {
        var result = await _mediator.Send(new GetSelectFaculitesQuery());
        return Ok(result);
    }
}