using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.DegreeType.Delete;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Inventory.Delete;

public class DeleteInventoryHandler(IInventoryRepository inventoryRepo, IMapper mapper)
    : ICommandHandler<DeleteInventoryComand, ResponseBase>
{
    public async Task<ResponseBase> Handle(DeleteInventoryComand request, CancellationToken cancellationToken)
    {
        var inventory = mapper.Map<domain.Entities.Inventory>(request.Request);
        bool isSuccess = await inventoryRepo.DeleteInventoryAsync(inventory.Id);
        return new ResponseBase(Data: inventory.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Inventory deleted." : "Inventory could not be deleted.");
    }
}