using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.DegreeType.GetDegreeType;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Inventory.GetInventory;

public class GetInventoryHandler (IInventoryRepository inventoryRepo, IMapper mapper) : IQueryHandler<GetInventoryQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetInventoryQuery request, CancellationToken cancellationToken)
    {
        var result = await inventoryRepo.GetInventoryByIdAsync(request.Id);
        return new ResponseBase(result);
    }
}