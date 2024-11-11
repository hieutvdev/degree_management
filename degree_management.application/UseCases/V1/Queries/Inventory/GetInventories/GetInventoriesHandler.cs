using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.DegreeType.GetDegreeTypes;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Inventory.GetInventories;

public class GetInventoriesHandler(IInventoryRepository inventoryRepo, IMapper mapper) : IQueryHandler<GetInventoriesQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetInventoriesQuery request, CancellationToken cancellationToken)
    {
        var inventories = await inventoryRepo.GetListInventoriesAsync(request.PaginationRequest, cancellationToken);
        return new ResponseBase(inventories);
    }
}