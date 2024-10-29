using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.DegreeType.GetDegreeTypes;

public class GetDegreeTypesHandler(IDegreeTypeRepository degreeTypeRepo, IMapper mapper) : IQueryHandler<GetDegreeTypesQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetDegreeTypesQuery request, CancellationToken cancellationToken)
    {
        var degreeTypes = await degreeTypeRepo.GetListDegreeTypesAsync(request.PaginationRequest, cancellationToken);
        return new ResponseBase(degreeTypes);
    }
}