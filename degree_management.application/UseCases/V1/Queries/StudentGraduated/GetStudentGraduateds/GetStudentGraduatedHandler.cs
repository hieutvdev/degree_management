using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.DegreeType.GetDegreeTypes;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.StudentGraduated.GetStudentGraduateds;

public class GetStudentGraduatedHandler(IStudentGraduatedRepository studentGraduatedRepo, IMapper mapper) : IQueryHandler<GetStudentGraduatedsQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetStudentGraduatedsQuery request, CancellationToken cancellationToken)
    {
        var students = await studentGraduatedRepo.GetListStudentGraduatedsAsync(request.SearchBase, cancellationToken);
        return new ResponseBase(students);
    }
}