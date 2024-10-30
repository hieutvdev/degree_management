using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.DegreeType.GetDegreeType;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Degree.GetDegree;

public class GetDegreeHandler (IDegreeRepository degreeRepo, IMapper mapper) : IQueryHandler<GetDegreeQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetDegreeQuery request, CancellationToken cancellationToken)
    {
        var result = await degreeRepo.GetDegreeByIdAsync(request.Id);
        return new ResponseBase(result);
    }
}