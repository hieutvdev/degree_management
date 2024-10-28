using degree_management.application.Data;
using degree_management.infrastructure.Data;
using degree_management.infrastructure.Data.Interceptors;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace degree_management.infrastructure.DepedencyInjection.Extensions;

public static class ServiceCollectionConfiguration
{
    const string CorsName = "inventory_cors";

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
        return services;
    }

    public static IServiceCollection RegisterService(this IServiceCollection services)
    {
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();


        return services;
    }


    public static WebApplication UseInfrastructureService(this WebApplication app)
    {
        app.UseCors(CorsName);
        return app;
    }
}