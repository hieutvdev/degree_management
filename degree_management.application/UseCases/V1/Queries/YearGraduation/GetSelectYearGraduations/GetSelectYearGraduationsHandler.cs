using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.Faculty.GetSelectFaculites;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.YearGraduation.GetSelectYearGraduations;

public class GetSelectYearGraduationsHandler (IYearGraduationRepository yearRepo, IMapper mapper) : IQueryHandler<GetSelectYearGraduationsQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetSelectYearGraduationsQuery request, CancellationToken cancellationToken)
    {
        var yearsSelect = await yearRepo.GetSelectAsync();
        return new ResponseBase(yearsSelect);
    }
}