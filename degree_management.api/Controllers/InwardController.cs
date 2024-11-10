using degree_management.application.Dtos.Requests.Inward;
using degree_management.application.Dtos.Requests.Inward.StockInInvSuggest;
using degree_management.application.UseCases.V1.Commands.Inventory.StockIn;
using degree_management.application.UseCases.V1.Commands.StockInSuggest.Create;
using degree_management.application.UseCases.V1.Commands.StockInSuggest.Update;
using degree_management.application.UseCases.V1.Queries.Inward.GetCodeStockInSuggest;
using degree_management.application.UseCases.V1.Queries.Inward.GetStockInInvSuggest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace degree_management.api.Controllers;

[Route("api/Inward")]
[ApiController]
public class InwardController : ControllerBase
{
    private readonly IMediator _mediator;

    public InwardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("create-inward-request")]
    public async Task<ActionResult> GetInwardRequest([FromQuery] string prefix)
    {
        var result = await _mediator.Send(new GetCodeStockInSuggestQuery(prefix));
        return Ok(result);
    }

    [HttpPost("create-inward-suggest")]
    public async Task<ActionResult> CraeteInwardSuggest([FromBody] CreateStockInInvSuggestRequest request)
    {
        var result = await _mediator.Send(new StockInSuggestCommand(request));
        return Ok(result);
    }

    [HttpGet("detail-inward-request")]
    public async Task<ActionResult> GetDetailInwardRequest([FromQuery] int id)
    {
        var result = await _mediator.Send(new GetStockInInvSuggestQuery(id));
        return Ok(result);
    }


    [HttpPut("update-inward-request")]
    public async Task<ActionResult> UpdateInwardRequest([FromBody] UpdateStockInInvSuggestRequest request)
    {
        var result = await _mediator.Send(new UpdateStockInSuggestCommand(request));
        return Ok(result);
    }
}
