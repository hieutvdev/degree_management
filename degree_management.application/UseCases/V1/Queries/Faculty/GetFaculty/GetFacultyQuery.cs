using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Faculty.GetFaculty;

public record GetFacultyQuery(int FacultyId) : IQuery<ResponseBase>;