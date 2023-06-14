using System.Diagnostics;
using FastEndpoints;
using FastEndpoints.Swagger;

namespace VotingApp.Web.Extensions;

public static class FastEndpointsExtensions
{
    public static IServiceCollection AddVotingAppSwagger(this IServiceCollection services)
    {
        services.AddSwaggerDoc(addJWTBearerAuth: false, settings: settings =>
        {
            settings.Title = "VotingApp API";
            settings.Version = "v1.0";
        });
        
        return services;
    }
    
    public static IServiceCollection AddVotingAppFastEndpoints(this IServiceCollection services)
    {
        services.AddFastEndpoints();
        
        return services;
    }

    public static WebApplication UseVotingAppFastEndpoints(this WebApplication host)
    {
        host.UseFastEndpoints(config =>
        {
            config.Endpoints.RoutePrefix = "api";
        });
        
        return host;
    }
}