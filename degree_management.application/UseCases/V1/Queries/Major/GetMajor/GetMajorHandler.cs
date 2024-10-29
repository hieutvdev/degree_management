using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.Major.GetMajors;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Major.GetMajor;

public class GetMajorHandler (IMajorRepository majorRepo, IMapper mapper) : IQueryHandler<GetMajorQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetMajorQuery request, CancellationToken cancellationToken)
    {
        var major = await majorRepo.GetMajorByIdAsync(request.MajorId);
        return new ResponseBase(major);
    }
}