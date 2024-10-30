using degree_management.application.Dtos.Faculty;
using degree_management.application.Dtos.Requests.Warehouse;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Warehouse.Delete;

public record DeleteWarehouseCommand(DeleteWarehouseRequest Request) : ICommand<ResponseBase>;