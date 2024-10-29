using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Faculty.GetSelectFaculites;

public class GetSelectFaculitesHandler (IFacultyRepository facultyRepo, IMapper mapper) : IQueryHandler<GetSelectFaculitesQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetSelectFaculitesQuery request, CancellationToken cancellationToken)
    {
        var faculitesSelect = await facultyRepo.GetSelectAsync();
        return new ResponseBase(faculitesSelect);
    }
}