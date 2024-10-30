using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.DegreeType.Create;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.StudentGraduated.Create;

public class CreateStudentGraduatedHandler(IStudentGraduatedRepository studentGraduatedRepo, IMapper mapper)
    : ICommandHandler<CreateStudentGraduatedCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(CreateStudentGraduatedCommand request, CancellationToken cancellationToken)
    {
        var studentGraduated = mapper.Map<domain.Entities.StudentGraduated>(request.Request);
        var isSuccess = await studentGraduatedRepo.CreateStudentGraduatedAsync(studentGraduated);
        return new ResponseBase(Data: studentGraduated.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Student created successfully!" : "Error creating major!");
    }
}