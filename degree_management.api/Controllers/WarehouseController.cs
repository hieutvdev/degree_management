using degree_management.application.Dtos.Requests.Warehouse;
using degree_management.application.UseCases.V1.Commands.Warehouse.Create;
using degree_management.application.UseCases.V1.Commands.Warehouse.Delete;
using degree_management.application.UseCases.V1.Commands.Warehouse.Update;
using degree_management.application.UseCases.V1.Queries.Faculty.GetFaculties;
using degree_management.application.UseCases.V1.Queries.Warehouse.GetSelectWarehouses;
using degree_management.application.UseCases.V1.Queries.Warehouse.GetWarehouse;
using degree_management.constracts.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace degree_management.api.Controllers;

[Route("api/Warehouse")]
[ApiController]
public class WarehouseController : ControllerBase
{
    private readonly IMediator _mediator;

    public WarehouseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-list")]
    public async Task<IActionResult> GetList([FromQuery] PaginationRequest paginationRequest)
    {
        var result = await _mediator.Send(new GetWarehousesQuery(paginationRequest));
        return Ok(result);
    }   
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateWarehouse([FromBody] CreateWarehouseRequest req)
    {
        var result = await _mediator.Send(new CreateWarehouseCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }   
    [HttpPut("update")]
    public async Task<IActionResult> UpdateWarehouse([FromBody] UpdateWarehouseRequest req)
    {
        var result = await _mediator.Send(new UpdateWarehouseCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }    
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteWarehouse([FromQuery] DeleteWarehouseRequest req)
    {
        var result = await _mediator.Send(new DeleteWarehouseCommand(req));
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

  
    [HttpGet("get-detail")]
    public async Task<IActionResult> GetDetail([FromQuery] int id)
    {
        var result = await _mediator.Send(new GetWarehouseQuery(id));
        return Ok(result);
    }

    [HttpGet("get-select")]
    public async Task<IActionResult> GetSelect()
    {
        var result = await _mediator.Send(new GetSelectWarehousesQuery());
        return Ok(result);
    }
}