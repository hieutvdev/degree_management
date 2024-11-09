using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Inward.GetCodeStockInSuggest;

public class GetCodeStockInSuggestHandler (IInwardRepository inwardRepo, IMapper mapper) : IQueryHandler<GetCodeStockInSuggestQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetCodeStockInSuggestQuery request, CancellationToken cancellationToken)
    {
        var result = await inwardRepo.GetStockInInvRequestAsync(request.Prefix);
        return new ResponseBase(result);
    }
}