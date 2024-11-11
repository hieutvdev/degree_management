using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Inventory.Update;

public class UpdateInventoryHandler(IInventoryRepository inventoryRepo, IMapper mapper)
    : ICommandHandler<UpdateInventoryComand, ResponseBase>
{
    public async Task<ResponseBase> Handle(UpdateInventoryComand request, CancellationToken cancellationToken)
    {
        var inventory = mapper.Map<domain.Entities.Inventory>(request.Request);
        var isSuccess = await inventoryRepo.UpdateInventoryAsync(inventory);
        return new ResponseBase(Data: inventory, IsSuccess: isSuccess,
            Message: isSuccess ? "Inventory type updated" : "Inventory type could not be updated");
    }
}