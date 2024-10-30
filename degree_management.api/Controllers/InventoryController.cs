using degree_management.application.Dtos.Requests.DegreeType;
using degree_management.application.Dtos.Requests.Inventory;
using degree_management.application.UseCases.V1.Commands.DegreeType.Create;
using degree_management.application.UseCases.V1.Commands.DegreeType.Delete;
using degree_management.application.UseCases.V1.Commands.DegreeType.Update;
using degree_management.application.UseCases.V1.Commands.Inventory.Create;
using degree_management.application.UseCases.V1.Commands.Inventory.Delete;
using degree_management.application.UseCases.V1.Commands.Inventory.Update;
using degree_management.application.UseCases.V1.Queries.DegreeType.GetDegreeType;
using degree_management.application.UseCases.V1.Queries.DegreeType.GetDegreeTypes;
using degree_management.application.UseCases.V1.Queries.DegreeType.GetSelectDegreeTypes;
using degree_management.application.UseCases.V1.Queries.Inventory.GetInventories;
using degree_management.application.UseCases.V1.Queries.Inventory.GetInventory;
using degree_management.constracts.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace degree_management.api.Controllers;

[Route("api/Invnetory")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public InventoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-list")]
    public async Task<IActionResult> GetList([FromQuery] PaginationRequest req)
    {
        var result = await _mediator.Send(new GetInventoriesQuery(req));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateInventoryRequest req)
    {
        var result = await _mediator.Send(new CreateInventoryCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateInventoryRequest req)
    {
        var result = await _mediator.Send(new UpdateInventoryComand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] DeleteInventoryRequest req)
    {
        var result = await _mediator.Send(new DeleteInventoryComand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("get-detail")]
    public async Task<IActionResult> GetDetail([FromQuery] int id)
    {
        var result = await _mediator.Send(new GetInventoryQuery(id));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

}