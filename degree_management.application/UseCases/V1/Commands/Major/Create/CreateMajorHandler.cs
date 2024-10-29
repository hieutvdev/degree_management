using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Major.Create;

public class CreateMajorHandler (IMajorRepository majorRepo, IMapper mapper) : ICommandHandler<CreateMajorCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(CreateMajorCommand request, CancellationToken cancellationToken)
    {
        var major = mapper.Map<domain.Entities.Major>(request.Request);
        var isSuccess = await majorRepo.CreateMajorAsync(major);
        return new ResponseBase(Data: major.Id, IsSuccess: isSuccess, Message: isSuccess ? "Major created successfully!" : "Error creating major!");
    }
}