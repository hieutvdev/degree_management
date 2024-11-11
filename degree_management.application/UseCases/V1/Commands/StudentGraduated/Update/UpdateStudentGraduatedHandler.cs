using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.DegreeType.Update;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.StudentGraduated.Update;

public class UpdateStudentGraduatedHandler(IStudentGraduatedRepository studentGraduatedRepo, IMapper mapper)
    : ICommandHandler<UpdateStudentGraduatedComand, ResponseBase>
{
    public async Task<ResponseBase> Handle(UpdateStudentGraduatedComand request, CancellationToken cancellationToken)
    {
        var studentGraduated = mapper.Map<domain.Entities.StudentGraduated>(request.Request);
        var isSuccess = await studentGraduatedRepo.UpdateStudentGraduatedAsync(studentGraduated);
        return new ResponseBase(Data: studentGraduated, IsSuccess: isSuccess,
            Message: isSuccess ? "Student type updated" : "Student type could not be updated");
    }
}