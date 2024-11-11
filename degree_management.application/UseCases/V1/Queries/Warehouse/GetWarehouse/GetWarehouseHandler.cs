using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.Faculty.GetFaculty;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Warehouse.GetWarehouse;

public class GetWarehouseHandler (IWarehouseRepository warehouseRepo, IMapper mapper) : IQueryHandler<GetWarehouseQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetWarehouseQuery request, CancellationToken cancellationToken)
    {
        var warehouse = await warehouseRepo.GetWarehouseByIdAsync(request.WarehouseId);
        return new ResponseBase(warehouse);
    }
}