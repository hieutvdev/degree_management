using System.Reflection;
using degree_management.application.Mappers;
using degree_management.constracts.Behaviors;
using degree_management.constracts.Exceptions.Handler;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

namespace degree_management.application.DependencyInjection.Extensions;

public static class ServiceCollectionConfiguration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddAutoMapper(typeof(ServiceProfile));
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
            config.AddOpenBehavior(typeof(PerformancePipelineBehavior<,>));
        });

        services.AddFeatureManagement();
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        return services;
    }


    public static WebApplication UseApplicationService(this WebApplication app)
    {
        app.UseExceptionHandler(config => { });

        return app;
    }
}