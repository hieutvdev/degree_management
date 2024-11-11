using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Inward.GetStockInRequests;

public class GetStockInRequestsHandler (IInwardRepository inwardRepo, IMapper mapper) : IQueryHandler<GetStockInRequestsQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetStockInRequestsQuery request, CancellationToken cancellationToken)
    {
        var result = await inwardRepo.GetStockInInvRequestsAsync(request.PaginationRequest);
        return new ResponseBase(result);
    }
}