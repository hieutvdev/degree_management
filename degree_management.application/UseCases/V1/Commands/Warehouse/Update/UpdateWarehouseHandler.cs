using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.Faculty.Update;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Warehouse.Update;

public class UpdateWarehouseHandler (IWarehouseRepository warehouseRepo, IMapper mapper) : ICommandHandler<UpdateWarehouseCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouse = mapper.Map<domain.Entities.Warehouse>(request.Request);
        var isSuccess = await warehouseRepo.UpdateWarehouseAsync(warehouse);
        return new ResponseBase(Data: warehouse.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Warehouse updated successfully" : "Warehouse could not be updated");
    }
}