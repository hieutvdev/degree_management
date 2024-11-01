using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.DegreeType.Delete;

public class DeleteDegreeTypeHandler(IDegreeTypeRepository degreeTypeRepo, IMapper mapper)
    : ICommandHandler<DeleteDegreeTypeComand, ResponseBase>
{
    public async Task<ResponseBase> Handle(DeleteDegreeTypeComand request, CancellationToken cancellationToken)
    {
        var degreeType = mapper.Map<domain.Entities.DegreeType>(request.Request);
        bool isSuccess = await degreeTypeRepo.DeleteDegreeTypeAsync(degreeType.Id);
        return new ResponseBase(Data: degreeType.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Degree type deleted." : "Degree type could not be deleted.");
    }
}