using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.Faculty.GetSelectFaculites;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Period.GetSelectPeriods;

public class GetSelectPeriodsHandler (IPeriodRepository periodRepo, IMapper mapper) : IQueryHandler<GetSelectPeriodsQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetSelectPeriodsQuery request, CancellationToken cancellationToken)
    {
        var periodsSelect = await periodRepo.GetSelectAsync();
        return new ResponseBase(periodsSelect);
    }
}