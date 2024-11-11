using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.Faculty.GetFaculties;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.YearGraduation.GetYearGraduations;

public class GetYearGraduationsHandler (IYearGraduationRepository yearRepo, IMapper mapper) : IQueryHandler<GetYearGraduationsQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetYearGraduationsQuery request, CancellationToken cancellationToken)
    {
        var years = await yearRepo.GetPageAsync(request.PaginationRequest, cancellationToken);
        return new ResponseBase(years);
    }
}