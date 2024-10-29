using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Faculty.Delete;

public class DeleteFacultyHandler (IFacultyRepository facultyRepo, IMapper mapper) : ICommandHandler<DeleteFacultyCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(DeleteFacultyCommand request, CancellationToken cancellationToken)
    {
        var faculty = mapper.Map<domain.Entities.Faculty>(request.Request);
        var isSuccess = await facultyRepo.DeleteAsync(faculty.Id);
        return new ResponseBase(Data: faculty.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Faculty deleted successfully" : "Faculty could not be deleted");
    }
}