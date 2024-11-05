using degree_management.application.Dtos.Requests.YearGraduation;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.YearGraduation.Create;
using degree_management.application.UseCases.V1.Commands.YearGraduation.Delete;
using degree_management.application.UseCases.V1.Commands.YearGraduation.Update;
using degree_management.application.UseCases.V1.Queries.Faculty.GetSelectFaculites;
using degree_management.application.UseCases.V1.Queries.YearGraduation.GetYearGraduations;
using degree_management.application.UseCases.V1.Queries.YearGraduation.GetYearGraduation;
using degree_management.application.UseCases.V1.Queries.YearGraduation.GetYearGraduations;
using degree_management.constracts.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace degree_management.api.Controllers;

[Route("api/YearGraduation")]
[ApiController]
public class YearGraduationController : ControllerBase
{
    private readonly IMediator _mediator;

    public YearGraduationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-list")]
    public async Task<IActionResult> GetList([FromQuery] PaginationRequest paginationRequest)
    {
        var result = await _mediator.Send(new GetYearGraduationsQuery(paginationRequest));
        return Ok(result);
    }   
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateYearGraduation([FromBody] CreateYearGraduationRequest req)
    {
        var result = await _mediator.Send(new CreateYearGraduationCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }   
    [HttpPut("update")]
    public async Task<IActionResult> UpdateYearGraduation([FromBody] UpdateYearGraduationRequest req)
    {
        var result = await _mediator.Send(new UpdateYearGraduationCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }    
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteYearGraduation([FromQuery] DeleteYearGraduationRequest req)
    {
        var result = await _mediator.Send(new DeleteYearGraduationCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

  
    [HttpGet("get-detail")]
    public async Task<IActionResult> GetDetail([FromQuery] int id)
    {
        var result = await _mediator.Send(new GetYearGraduationQuery(id));
        return Ok(result);
    }

    [HttpGet("get-select")]
    public async Task<IActionResult> GetSelect()
    {
        var result = await _mediator.Send(new GetSelectFaculitesQuery());
        return Ok(result);
    }
}