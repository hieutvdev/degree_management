using degree_management.application.Dtos.Requests.DegreeType;
using degree_management.application.UseCases.V1.Commands.DegreeType.Create;
using degree_management.application.UseCases.V1.Queries.DegreeType.GetDegreeTypes;
using degree_management.constracts.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace degree_management.api.Controllers;

[Route("api/DegreeType")]
[ApiController]
public class DegreeTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public DegreeTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-list")]
    public async Task<IActionResult> GetList([FromQuery] PaginationRequest req)
    {
        var result = await _mediator.Send(new GetDegreeTypesQuery(req));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateDegreeTypeRequest req)
    {
        var result = await _mediator.Send(new CreateDegreeTypeCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}