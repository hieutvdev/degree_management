using degree_management.application.Dtos.Requests.Warehouse;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Warehouse.Update;

public record UpdateWarehouseCommand(UpdateWarehouseRequest Request): ICommand<ResponseBase>;