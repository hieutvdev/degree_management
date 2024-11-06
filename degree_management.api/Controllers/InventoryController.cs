using degree_management.application.Dtos.Requests.Inventory;
using degree_management.application.UseCases.V1.Commands.Inventory.StockIn;
using degree_management.application.UseCases.V1.Queries.Inventory.GetInventories;
using degree_management.application.UseCases.V1.Queries.Inventory.GetInventory;
using degree_management.constracts.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace degree_management.api.Controllers;

[Route("api/Inventory")]
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

    [HttpPost("stock-in")]
    public async Task<IActionResult> StockIn([FromBody] StockInInvRequest req)
    {
        var result = await _mediator.Send(new StockInInventoryCommand(req));
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