using AutoMapper;
using degree_management.application.Dtos.Faculty;
using degree_management.application.Dtos.Requests.Degree;
using degree_management.application.Dtos.Requests.DegreeType;
using degree_management.application.Dtos.Requests.Major;
using degree_management.application.Dtos.Requests.StudentGraduated;
using degree_management.application.Dtos.Requests.Warehouse;
using degree_management.application.Dtos.Responses.Degree;
using degree_management.application.Dtos.Responses.DegreeType;
using degree_management.application.Dtos.Responses.Faculty;
using degree_management.application.Dtos.Responses.Major;
using degree_management.application.Dtos.Responses.StudentGraduated;
using degree_management.application.Dtos.Responses.Warehouse;
using degree_management.domain.Entities;

namespace degree_management.application.Mappers;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<CreateFacultyRequest, Faculty>().ReverseMap();
        CreateMap<UpdateFacultyRequest, Faculty>().ReverseMap();
        CreateMap<DeleteFacultyRequest, Faculty>().ReverseMap();
        CreateMap<Faculty, FacultyDto>().ReverseMap();
        CreateMap<CreateMajorRequest, Major>().ReverseMap();
        CreateMap<UpdateMajorRequest, Major>().ReverseMap();
        CreateMap<DeleteMajorRequest, Major>().ReverseMap();
        CreateMap<Major, MajorDto>().ReverseMap();
        CreateMap<CreateDegreeTypeRequest, DegreeType>().ReverseMap();
        CreateMap<UpdateDegreeTypeRequest, DegreeType>().ReverseMap();
        CreateMap<DeleteDegreeTypeRequest, DegreeType>().ReverseMap();
        CreateMap<DegreeType, DegreeTypeDto>().ReverseMap();
        CreateMap<CreateStudentGraduatedRequest, StudentGraduated>().ReverseMap();
        CreateMap<UpdateStudentGraduatedRequest, StudentGraduated>().ReverseMap();
        CreateMap<DeleteStudentGraduatedRequest, StudentGraduated>().ReverseMap();
        CreateMap<StudentGraduated, StudentGraduatedDto>().ReverseMap();
        CreateMap<CreateDegreeRequest, Degree>().ReverseMap();
        CreateMap<UpdateDegreeRequest, Degree>().ReverseMap();
        CreateMap<DeleteDegreeRequest, Degree>().ReverseMap();
        CreateMap<Degree, DegreeDto>().ReverseMap();
        CreateMap<CreateWarehouseRequest, Warehouse>().ReverseMap();
        CreateMap<UpdateWarehouseRequest, Warehouse>().ReverseMap();
        CreateMap<DeleteWarehouseRequest, Warehouse>().ReverseMap();
        CreateMap<Warehouse, WarehouseDto>().ReverseMap();
    }
}