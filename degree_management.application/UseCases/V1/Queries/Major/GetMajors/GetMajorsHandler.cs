using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Major.GetMajors;

public class GetMajorsHandler(IMajorRepository majorRepo, IMapper mapper) : IQueryHandler<GetMajorsQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetMajorsQuery request, CancellationToken cancellationToken)
    {
        var majors = await majorRepo.GetPageAsync(request.PaginationRequest, cancellationToken);
        return new ResponseBase(majors);
    }
}