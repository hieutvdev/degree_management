using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.DegreeType.Update;

public class UpdateDegreeTypeHandler(IDegreeTypeRepository degreeTypeRepo, IMapper mapper)
    : ICommandHandler<UpdateDegreeTypeComand, ResponseBase>
{
    public async Task<ResponseBase> Handle(UpdateDegreeTypeComand request, CancellationToken cancellationToken)
    {
        var degreeType = mapper.Map<domain.Entities.DegreeType>(request.Request);
        var isSuccess = await degreeTypeRepo.UpdateDegreeTypeAsync(degreeType);
        return new ResponseBase(Data: degreeType, IsSuccess: isSuccess,
            Message: isSuccess ? "Degree type updated" : "Degree type could not be updated");
    }
}