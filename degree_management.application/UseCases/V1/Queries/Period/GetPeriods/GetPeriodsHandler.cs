using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.Faculty.GetFaculties;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Period.GetPeriods;

public class GetPeriodsHandler (IPeriodRepository periodRepo, IMapper mapper) : IQueryHandler<GetPeriodsQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetPeriodsQuery request, CancellationToken cancellationToken)
    {
        var periods = await periodRepo.GetPageAsync(request.PaginationRequest, cancellationToken);
        return new ResponseBase(periods);
    }
}