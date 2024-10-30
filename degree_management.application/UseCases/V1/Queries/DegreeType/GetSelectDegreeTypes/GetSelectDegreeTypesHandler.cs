using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.DegreeType.GetSelectDegreeTypes;

public class GetSelectDegreeTypesHandler (IDegreeTypeRepository degreeTypeRepo, IMapper mapper) : IQueryHandler<GetSelectDegreeTypesQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetSelectDegreeTypesQuery request, CancellationToken cancellationToken)
    {
        var degreeTypesSelect = await degreeTypeRepo.GetSelectDegreeTypesAsync();
        return new ResponseBase(degreeTypesSelect);
    }
}