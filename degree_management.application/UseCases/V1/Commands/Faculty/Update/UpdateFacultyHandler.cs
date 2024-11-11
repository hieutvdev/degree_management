using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Faculty.Update;

public class UpdateFacultyHandler (IFacultyRepository facultyRepo, IMapper mapper) : ICommandHandler<UpdateFacultyCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(UpdateFacultyCommand request, CancellationToken cancellationToken)
    {
        var faculty = mapper.Map<domain.Entities.Faculty>(request.Request);
        var isSuccess = await facultyRepo.UpdateAsync(faculty);
        return new ResponseBase(Data: faculty.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Faculty updated successfully" : "Faculty could not be updated");
    }
}