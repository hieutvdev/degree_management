using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.DegreeType.GetDegreeTypes;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Degree.GetDegrees;

public class GetDegreesHandler(IDegreeRepository degreeRepo, IMapper mapper) : IQueryHandler<GetDegreesQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetDegreesQuery request, CancellationToken cancellationToken)
    {
        var degrees = await degreeRepo.GetListDegreesAsync(request.PaginationRequest, cancellationToken);
        return new ResponseBase(degrees);
    }
}