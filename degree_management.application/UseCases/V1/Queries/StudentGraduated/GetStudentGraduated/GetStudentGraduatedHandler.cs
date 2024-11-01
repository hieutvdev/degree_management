using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.DegreeType.GetDegreeType;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.StudentGraduated.GetStudentGraduated;

public class GetStudentGraduatedHandler (IStudentGraduatedRepository studentGraduatedRepo, IMapper mapper) : IQueryHandler<GetStudentGraduatedQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetStudentGraduatedQuery request, CancellationToken cancellationToken)
    {
        var result = await studentGraduatedRepo.GetStudentGraduatedByIdAsync(request.Id);
        return new ResponseBase(result);
    }
}