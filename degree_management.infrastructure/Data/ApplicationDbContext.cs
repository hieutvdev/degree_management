using System.Reflection;
using degree_management.application.Data;
using degree_management.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace degree_management.infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Faculty> Faculties  => Set<Faculty>();
    public DbSet<Major> Majors => Set<Major>();
    public DbSet<StudentGraduated> StudentGraduateds => Set<StudentGraduated>();
    public DbSet<DegreeType> DegreeTypes => Set<DegreeType>();
    public DbSet<Degree> Degrees => Set<Degree>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<Inventory> Inventories => Set<Inventory>();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
