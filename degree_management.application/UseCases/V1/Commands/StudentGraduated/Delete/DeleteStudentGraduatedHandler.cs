using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.DegreeType.Delete;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.StudentGraduated.Delete;

public class DeleteStudentGraduatedHandler(IStudentGraduatedRepository studentGraduatedRepo, IMapper mapper)
    : ICommandHandler<DeleteStudentGraduatedComand, ResponseBase>
{
    public async Task<ResponseBase> Handle(DeleteStudentGraduatedComand request, CancellationToken cancellationToken)
    {
        var studentGraduated = mapper.Map<domain.Entities.StudentGraduated>(request.Request);
        bool isSuccess = await studentGraduatedRepo.DeleteStudentGraduatedAsync(studentGraduated.Id);
        return new ResponseBase(Data: studentGraduated.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Student type deleted." : "Degree type could not be deleted.");
    }
}