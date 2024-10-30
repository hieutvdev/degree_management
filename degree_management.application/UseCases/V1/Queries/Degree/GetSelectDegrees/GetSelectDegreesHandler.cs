using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.DegreeType.GetSelectDegreeTypes;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Degree.GetSelectDegrees;

public class GetSelectDegreesHandler (IDegreeRepository degreeRepo, IMapper mapper) : IQueryHandler<GetSelectDegreesQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetSelectDegreesQuery request, CancellationToken cancellationToken)
    {
        var degreesSelect = await degreeRepo.GetSelectDegreesAsync();
        return new ResponseBase(degreesSelect);
    }
}