using degree_management.application.Data;
using degree_management.application.Repositories;
using degree_management.constracts.RepositoryBase.EntityFramework;
using degree_management.infrastructure.Data;
using degree_management.infrastructure.Data.Interceptors;
using degree_management.infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace degree_management.infrastructure.DepedencyInjection.Extensions;

public static class ServiceCollectionConfiguration
{
    const string CorsName = "degree_cors";

    public static IServiceCollection AddInfrastructureService(this IServiceCollection services,
        IConfiguration configuration)
    {
        var databaseConnectionString = configuration.GetConnectionString("DefaultConnection");


        services.AddCors(builder =>
        {
            builder.AddPolicy(name: CorsName, options =>
            {
                options.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();


        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            var interceptors = sp.GetServices<ISaveChangesInterceptor>().ToArray();
            options.AddInterceptors(interceptors);
            options.UseSqlServer(databaseConnectionString);
        });

        services.RegisterRepository();
        services.RegisterService();


        return services;
    }

    public static IServiceCollection RegisterRepository(this IServiceCollection services)
    {
        services.AddScoped<IFacultyRepository, FacultyRepository>();
        services.AddScoped<IMajorRepository, MajorRepository>();
        services.AddScoped<IDegreeTypeRepository, DegreeTypeRepository>();
        services.AddScoped<IStudentGraduatedRepository, StudentGraduatedRepository>();
        services.AddScoped<IDegreeRepository, DegreeRepository>();
        services.AddScoped<IWarehouseRepository, WarehouseRepository>();
        return services;
    }

    public static IServiceCollection RegisterService(this IServiceCollection services)
    {
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

        return services;
    }


    public static WebApplication UseInfrastructureService(this WebApplication app)
    {
        app.UseCors(CorsName);
        return app;
    }
}