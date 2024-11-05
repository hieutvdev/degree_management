using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.Faculty.Create;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Specialization.Create;

public class CreateSpecializationHandler(ISpecializationRepository specializationRepo, IMapper mapper)
    : ICommandHandler<CreateSpecializationCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
    {
        var specialization = mapper.Map<domain.Entities.Specialization>(request.Request);
        var isSuccess = await specializationRepo.CreateAsync(specialization);
        return new ResponseBase(Data: specialization.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Specialization created successfully" : "Specialization could not be created");
    }
}