using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Warehouse.Create;

public class CreateWarehouseHandler(IWarehouseRepository warehouseRepo, IMapper mapper)
    : ICommandHandler<CreateWarehouseCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouse = mapper.Map<domain.Entities.Warehouse>(request.Request);
        var isSuccess = await warehouseRepo.CreateWarehouseAsync(warehouse);
        return new ResponseBase(Data: warehouse.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Warehouse created successfully" : "Warehouse could not be created");
    }
}