using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.DegreeType.GetSelectDegreeTypes;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.StudentGraduated.GetSelectStudentGraduateds;

public class GetStudentGraduatedsHandler (IStudentGraduatedRepository studentGraduatedRepo, IMapper mapper) : IQueryHandler<GetSelectStudentGraduatedsQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetSelectStudentGraduatedsQuery request, CancellationToken cancellationToken)
    {
        var studentGraduatedsSelect = await studentGraduatedRepo.GetSelectStudentGraduatedsAsync();
        return new ResponseBase(studentGraduatedsSelect);
    }
}