using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.Faculty.GetFaculties;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Warehouse.GetWarehouses;

public class GetWarehousesHandler (IWarehouseRepository warehouseRepo, IMapper mapper) : IQueryHandler<GetWarehousesQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetWarehousesQuery request, CancellationToken cancellationToken)
    {
        var warehouses = await warehouseRepo.GetListWarehousesAsync(request.PaginationRequest, cancellationToken);
        return new ResponseBase(warehouses);
    }
}