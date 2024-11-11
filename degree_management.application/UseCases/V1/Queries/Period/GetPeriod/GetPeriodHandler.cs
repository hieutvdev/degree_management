using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.Faculty.GetFaculty;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Period.GetPeriod;

public class GetPeriodHandler (IPeriodRepository periodRepo, IMapper mapper) : IQueryHandler<GetPeriodQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetPeriodQuery request, CancellationToken cancellationToken)
    {
        var period = await periodRepo.GetByIdAsync(request.PeriodId);
        return new ResponseBase(period);
    }
}