using degree_management.application.Dtos.Requests.DegreeType;
using degree_management.application.Dtos.Requests.Inventory;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Inventory.Create;

public record CreateInventoryCommand(CreateInventoryRequest Request): ICommand<ResponseBase>;