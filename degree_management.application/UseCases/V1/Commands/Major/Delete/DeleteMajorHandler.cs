using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.Faculty.Delete;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Major.Delete;

public class DeleteMajorHandler (IMajorRepository majorRepo, IMapper mapper) : ICommandHandler<DeleteMajorCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(DeleteMajorCommand request, CancellationToken cancellationToken)
    {
        var major = mapper.Map<domain.Entities.Major>(request.Request);
        var isSuccess = await majorRepo.DeleteMajorAsync(major.Id);
        return new ResponseBase(Data: major.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Major deleted successfully" : "Major could not be deleted");
    }
}