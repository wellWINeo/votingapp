using System.Reflection;
using Microsoft.EntityFrameworkCore;
using VotingApp.Web.Infrastructure;

namespace VotingApp.Web.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<VotingAppContext>(
            options => options.UseNpgsql(connectionString)
        );
        
        return services;
    }

    public static void MapEntities(this ModelBuilder builder)
    {
            builder.ApplyConfigurationsFromAssembly(typeof(VotingAppContext).Assembly);
    }
}