using degree_management.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace degree_management.application.Data;

public interface IApplicationDbContext 
{
    DbSet<Faculty> Faculties { get; }
    DbSet<Major> Majors { get; }
    DbSet<StudentGraduated> StudentGraduateds { get; }
    DbSet<DegreeType> DegreeTypes { get; }
    DbSet<Degree> Degrees { get; }
    DbSet<Warehouse> Warehouses { get; }
    DbSet<Inventory> Inventories { get; }
    DbSet<Specialization> Specializations { get; }
    DbSet<YearGraduation> YearGraduations { get; }
    DbSet<Period> Periods { get; }
    DbSet<StockInInvSuggest> StockInInvSuggests { get; }
    DbSet<StockInInvSuggestDetail> StockInInvSuggestDetails { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}