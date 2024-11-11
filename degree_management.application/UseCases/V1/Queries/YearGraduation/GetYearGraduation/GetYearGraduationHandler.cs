using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.Faculty.GetFaculty;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.YearGraduation.GetYearGraduation;

public class GetYearGraduationHandler (IYearGraduationRepository yearRepo, IMapper mapper) : IQueryHandler<GetYearGraduationQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetYearGraduationQuery request, CancellationToken cancellationToken)
    {
        var year = await yearRepo.GetByIdAsync(request.YearId);
        return new ResponseBase(year);
    }
}