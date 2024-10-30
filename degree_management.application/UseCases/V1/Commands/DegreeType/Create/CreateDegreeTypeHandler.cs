using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.DegreeType.Create;

public class CreateDegreeTypeHandler(IDegreeTypeRepository degreeTypeRepo, IMapper mapper)
    : ICommandHandler<CreateDegreeTypeCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(CreateDegreeTypeCommand request, CancellationToken cancellationToken)
    {
        var degreeType = mapper.Map<domain.Entities.DegreeType>(request.Request);
        var isSuccess = await degreeTypeRepo.CreateDegreeTypeAsync(degreeType);
        return new ResponseBase(Data: degreeType.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "DegreeType created successfully!" : "Error creating major!");
    }
}