using degree_management.application.Dtos.Requests.Inventory;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Inventory.StockIn;

public record StockInInventoryCommand(StockInInvRequest Request) : ICommand<ResponseBase>;