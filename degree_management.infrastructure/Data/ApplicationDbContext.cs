using System.Reflection;
using degree_management.application.Data;
using degree_management.domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace degree_management.infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>, IApplicationDbContext
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
        base.OnModelCreating(builder);
        builder.Entity<ApplicationUser>(options =>
        {
            options.ToTable("Users");
          
        });
        builder.Entity<ApplicationRole>(options =>
        {
            options.ToTable("Roles");
          
        });
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
