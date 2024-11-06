using degree_management.application.Dtos.Requests.StudentGraduated;
using degree_management.application.UseCases.V1.Commands.StudentGraduated.Create;
using degree_management.application.UseCases.V1.Commands.StudentGraduated.Delete;
using degree_management.application.UseCases.V1.Commands.StudentGraduated.Update;
using degree_management.application.UseCases.V1.Queries.DegreeType.GetDegreeTypes;
using degree_management.application.UseCases.V1.Queries.StudentGraduated.GetSelectStudentGraduateds;
using degree_management.application.UseCases.V1.Queries.StudentGraduated.GetStudentGraduated;
using degree_management.constracts.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace degree_management.api.Controllers;

[Route("api/StudentGraduated")]
[ApiController]
public class StudentGraduatedController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentGraduatedController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-list")]
    public async Task<IActionResult> GetList([FromQuery] PaginationRequest req)
    {
        var result = await _mediator.Send(new GetStudentGraduatedsQuery(req));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateStudentGraduatedRequest req)
    {
        var result = await _mediator.Send(new CreateStudentGraduatedCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("create-list")]
    public async Task<IActionResult> CreateList([FromBody] BulkCreateStudentGraduatedRequest req)
    {
        var result = await _mediator.Send(new BulkCreateStudentGraduatedCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateStudentGraduatedRequest req)
    {
        var result = await _mediator.Send(new UpdateStudentGraduatedComand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] DeleteStudentGraduatedRequest req)
    {
        var result = await _mediator.Send(new DeleteStudentGraduatedComand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("get-detail")]
    public async Task<IActionResult> GetDetail([FromQuery] int id)
    {
        var result = await _mediator.Send(new GetStudentGraduatedQuery(id));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpGet("get-select")]
    public async Task<IActionResult> GetSelect()
    {
        var result = await _mediator.Send(new GetSelectStudentGraduatedsQuery());
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}