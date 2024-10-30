using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.Faculty.Delete;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Warehouse.Delete;

public class DeleteWarehouseHandler (IWarehouseRepository warehouseRepo, IMapper mapper) : ICommandHandler<DeleteWarehouseCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouse = mapper.Map<domain.Entities.Warehouse>(request.Request);
        var isSuccess = await warehouseRepo.DeleteWarehouseAsync(warehouse.Id);
        return new ResponseBase(Data: warehouse.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Warehouse deleted successfully" : "Warehouse could not be deleted");
    }
}