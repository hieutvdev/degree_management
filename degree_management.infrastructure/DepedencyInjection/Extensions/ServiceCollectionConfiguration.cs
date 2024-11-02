using System.Text;
using degree_management.application.Data;
using degree_management.application.Repositories;
using degree_management.application.Services;
using degree_management.constracts.RepositoryBase.EntityFramework;
using degree_management.domain.Entities;
using degree_management.infrastructure.Configurations;
using degree_management.infrastructure.Data;
using degree_management.infrastructure.Data.Interceptors;
using degree_management.infrastructure.Repositories;
using degree_management.infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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

        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        services.AddJwtServiceCollection(configuration);
        services.RegisterRepository();
        services.RegisterService();


        return services;
    }

    public static IServiceCollection AddJwtServiceCollection(this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddHttpContextAccessor();
        
        services.Configure<JwtConfiguration>(configuration.GetSection("JwtConfiguration"));
        var jwtToken = new JwtConfiguration();
        configuration.GetSection("JwtConfiguration").Bind(jwtToken);
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtToken.Secret));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = true,
                ValidIssuer = jwtToken.Issuer,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidAudience = jwtToken.Audience,
                ClockSkew = TimeSpan.Zero,
            };
        });
        
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidIssuer = jwtToken.Issuer,
            ValidateAudience = false,
            ValidAudience = jwtToken.Audience,
            RequireExpirationTime = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        services.AddSingleton(tokenValidationParameters);
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
        services.AddScoped<IInventoryRepository, InventoryRepository>();
        return services;
    }

    public static IServiceCollection RegisterService(this IServiceCollection services)
    {
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }


    public static WebApplication UseInfrastructureService(this WebApplication app)
    {
        app.UseCors(CorsName);
        return app;
    }
}