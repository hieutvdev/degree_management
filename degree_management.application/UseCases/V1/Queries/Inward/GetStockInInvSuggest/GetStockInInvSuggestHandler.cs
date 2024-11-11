using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Inward.GetStockInInvSuggest;

public class GetStockInInvSuggestHandler (IInwardRepository inwardRepo, IMapper mapper) : IQueryHandler<GetStockInInvSuggestQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetStockInInvSuggestQuery request, CancellationToken cancellationToken)
    {
        var result = await inwardRepo.GetStockInInvRequestAsync(request.StockInInvId);
        return new ResponseBase(result);
    }
}