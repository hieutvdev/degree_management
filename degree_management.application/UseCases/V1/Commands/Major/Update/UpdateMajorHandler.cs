using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Major.Update;

public class UpdateMajorHandler(IMajorRepository majorRepo, IMapper mapper) : ICommandHandler<UpdateMajorCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(UpdateMajorCommand request, CancellationToken cancellationToken)
    {
       var major = mapper.Map<domain.Entities.Major>(request.Request);
       var isSuccess = await majorRepo.UpdateMajorAsync(major);
       return new ResponseBase(Data: major.Id, IsSuccess: isSuccess,
           Message: isSuccess ? "Major updated successfully" : "Major could not be updated");
    }
}