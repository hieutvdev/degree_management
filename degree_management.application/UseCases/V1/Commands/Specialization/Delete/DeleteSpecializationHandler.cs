using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.Faculty.Delete;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Specialization.Delete;

public class DeleteSpecializationHandler (ISpecializationRepository specializationRepo, IMapper mapper) : ICommandHandler<DeleteSpecializationCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
    {
        var specialization = mapper.Map<domain.Entities.Specialization>(request.Request);
        var isSuccess = await specializationRepo.DeleteAsync(specialization.Id);
        return new ResponseBase(Data: specialization.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Specialization deleted successfully" : "Specialization could not be deleted");
    }
}