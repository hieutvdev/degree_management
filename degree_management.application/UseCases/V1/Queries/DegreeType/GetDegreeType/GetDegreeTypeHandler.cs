using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.DegreeType.GetDegreeType;

public class GetDegreeTypeHandler (IDegreeTypeRepository degreeTypeRepo, IMapper mapper) : IQueryHandler<GetDegreeTypeQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetDegreeTypeQuery request, CancellationToken cancellationToken)
    {
        var result = await degreeTypeRepo.GetDegreeTypeByIdAsync(request.Id);
        return new ResponseBase(result);
    }
}