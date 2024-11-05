using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.Faculty.Update;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Specialization.Update;

public class UpdateSpecializationHandler (ISpecializationRepository specializationRepo, IMapper mapper) : ICommandHandler<UpdateSpecializationCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
    {
        var specialization = mapper.Map<domain.Entities.Specialization>(request.Request);
        var isSuccess = await specializationRepo.UpdateAsync(specialization);
        return new ResponseBase(Data: specialization.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Specialization updated successfully" : "Specialization could not be updated");
    }
}