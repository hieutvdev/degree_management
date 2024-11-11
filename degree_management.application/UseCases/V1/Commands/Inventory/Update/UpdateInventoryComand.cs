using degree_management.application.Dtos.Requests.Inventory;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Inventory.Update;

public record UpdateInventoryComand(UpdateInventoryRequest Request) : ICommand<ResponseBase>;