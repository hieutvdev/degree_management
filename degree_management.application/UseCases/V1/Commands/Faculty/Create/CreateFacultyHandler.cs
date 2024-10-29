using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Faculty.Create;

public class CreateFacultyHandler(IFacultyRepository facultyRepo, IMapper mapper)
    : ICommandHandler<CreateFacultyCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
    {
        var faculty = mapper.Map<domain.Entities.Faculty>(request.Request);
        var isSuccess = await facultyRepo.CreateAsync(faculty);
        return new ResponseBase(Metadata: faculty.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Faculty created successfully" : "Faculty could not be created");
    }
}