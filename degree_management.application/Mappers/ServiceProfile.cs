using AutoMapper;
using degree_management.application.Dtos.Faculty;
using degree_management.application.Dtos.Requests.Degree;
using degree_management.application.Dtos.Requests.DegreeType;
using degree_management.application.Dtos.Requests.Inventory;
using degree_management.application.Dtos.Requests.Inward;
using degree_management.application.Dtos.Requests.Inward.StockInInvSuggest;
using degree_management.application.Dtos.Requests.Major;
using degree_management.application.Dtos.Requests.Period;
using degree_management.application.Dtos.Requests.Specialization;
using degree_management.application.Dtos.Requests.StudentGraduated;
using degree_management.application.Dtos.Requests.Warehouse;
using degree_management.application.Dtos.Requests.YearGraduation;
using degree_management.application.Dtos.Responses.Auth;
using degree_management.application.Dtos.Responses.Degree;
using degree_management.application.Dtos.Responses.DegreeType;
using degree_management.application.Dtos.Responses.Faculty;
using degree_management.application.Dtos.Responses.Inventory;
using degree_management.application.Dtos.Responses.Major;
using degree_management.application.Dtos.Responses.Period;
using degree_management.application.Dtos.Responses.Specialization;
using degree_management.application.Dtos.Responses.StudentGraduated;
using degree_management.application.Dtos.Responses.Warehouse;
using degree_management.application.Dtos.Responses.YearGraduation;
using degree_management.domain.Entities;

namespace degree_management.application.Mappers;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        #region Faculty

        CreateMap<CreateFacultyRequest, Faculty>().ReverseMap();
        CreateMap<UpdateFacultyRequest, Faculty>().ReverseMap();
        CreateMap<DeleteFacultyRequest, Faculty>().ReverseMap();
        CreateMap<Faculty, FacultyDto>().ReverseMap();

        #endregion

        #region Major

        CreateMap<CreateMajorRequest, Major>().ReverseMap();
        CreateMap<UpdateMajorRequest, Major>().ReverseMap();
        CreateMap<DeleteMajorRequest, Major>().ReverseMap();
        CreateMap<Major, MajorDto>().ReverseMap();

        #endregion


        #region DegreeType

        CreateMap<CreateDegreeTypeRequest, DegreeType>().ReverseMap();
        CreateMap<UpdateDegreeTypeRequest, DegreeType>().ReverseMap();
        CreateMap<DeleteDegreeTypeRequest, DegreeType>().ReverseMap();
        CreateMap<DegreeType, DegreeTypeDto>().ReverseMap();

        #endregion


        #region Student

        CreateMap<CreateStudentGraduatedRequest, StudentGraduated>().ReverseMap();
        CreateMap<UpdateStudentGraduatedRequest, StudentGraduated>().ReverseMap();
        CreateMap<DeleteStudentGraduatedRequest, StudentGraduated>().ReverseMap();
        CreateMap<StudentGraduated, StudentGraduatedDto>().ReverseMap();

        #endregion

        #region DegreeRequest

        CreateMap<CreateDegreeRequest, Degree>().ReverseMap();
        CreateMap<UpdateDegreeRequest, Degree>().ReverseMap();
        CreateMap<DeleteDegreeRequest, Degree>().ReverseMap();
        CreateMap<Degree, DegreeDto>().ReverseMap();

        #endregion


        #region Warehouses

        CreateMap<CreateWarehouseRequest, Warehouse>().ReverseMap();
        CreateMap<UpdateWarehouseRequest, Warehouse>().ReverseMap();
        CreateMap<DeleteWarehouseRequest, Warehouse>().ReverseMap();
        CreateMap<Warehouse, WarehouseDto>().ReverseMap();

        #endregion


        #region Inventory

        CreateMap<CreateInventoryRequest, Inventory>().ReverseMap();
        CreateMap<UpdateInventoryRequest, Inventory>().ReverseMap();
        CreateMap<DeleteInventoryRequest, Inventory>().ReverseMap();
        CreateMap<Inventory, InventoryDto>().ReverseMap();
        CreateMap<StockInInvRequest, Inventory>().ReverseMap();

        #endregion


        #region YearGraduation

        CreateMap<CreateYearGraduationRequest, YearGraduation>().ReverseMap();
        CreateMap<UpdateYearGraduationRequest, YearGraduation>().ReverseMap();
        CreateMap<DeleteYearGraduationRequest, YearGraduation>().ReverseMap();
        CreateMap<YearGraduation, YearGraduationDto>().ReverseMap();

        #endregion


        #region Period

        CreateMap<CreatePeriodRequest, Period>().ReverseMap();
        CreateMap<UpdatePeriodRequest, Period>().ReverseMap();
        CreateMap<DeletePeriodRequest, Period>().ReverseMap();
        CreateMap<Period, PeriodDto>().ReverseMap();

        #endregion

        #region Specialization

        CreateMap<CreateSpecializationRequest, Specialization>().ReverseMap();
        CreateMap<UpdateSpecializationRequest, Specialization>().ReverseMap();
        CreateMap<DeleteSpecializationRequest, Specialization>().ReverseMap();
        CreateMap<Specialization, SpecializationDto>().ReverseMap();

        #endregion

        #region Inward

        CreateMap<CreateStockInInvSuggestRequest, StockInInvSuggest>().ReverseMap();

        #endregion

        #region Auth

        CreateMap<ApplicationUser, UserDto>().ReverseMap();

        #endregion
    }
}