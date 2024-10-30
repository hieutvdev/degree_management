using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.DegreeType.Create;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Inventory.Create;

public class CreateInventoryHandler(IInventoryRepository inventoryRepo, IMapper mapper)
    : ICommandHandler<CreateInventoryCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
    {
        var inventory = mapper.Map<domain.Entities.Inventory>(request.Request);
        var isSuccess = await inventoryRepo.CreateInventoryAsync(inventory);
        return new ResponseBase(Data: inventory.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Inventory created successfully!" : "Error creating major!");
    }
}