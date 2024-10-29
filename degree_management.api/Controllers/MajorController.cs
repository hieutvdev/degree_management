using degree_management.application.Dtos.Requests.Major;
using degree_management.application.UseCases.V1.Commands.Major.Create;
using degree_management.application.UseCases.V1.Queries.Major.GetMajors;
using degree_management.constracts.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace degree_management.api.Controllers;

[Route("api/Major")]
[ApiController]
public class MajorController : ControllerBase
{
    private readonly IMediator _mediator;

    public MajorController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("get-list")]
    public async Task<IActionResult> GetListMajor([FromQuery] PaginationRequest paginationRequest)
    {
        var result = await _mediator.Send(new GetMajorsQuery(paginationRequest));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateMajor(CreateMajorRequest req)
    {
        var result = await _mediator.Send(new CreateMajorCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

   
}