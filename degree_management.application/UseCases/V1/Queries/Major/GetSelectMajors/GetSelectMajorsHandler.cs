using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Major.GetSelectMajors;

public class GetSelectMajorsHandler (IMajorRepository majorRepo, IMapper mapper) : IQueryHandler<GetSelectMajorsQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetSelectMajorsQuery request, CancellationToken cancellationToken)
    {
        var majorsSelect = await majorRepo.GetSelectAsync();
        return new ResponseBase(majorsSelect);
    }
}