using VotingApp.Web.Core.Exceptions;
using VotingApp.Web.Extensions;

namespace VotingApp.Web.Core.Configuration;

public class VotingDatabaseOptions
{
    public string ConnectionString { get; init; }
    public string Password { get; init; }

    public static VotingDatabaseOptions Create(IConfiguration configuration)
    {
        return configuration
            .GetSection("Database")
            .Get<VotingDatabaseOptions>()
            .OrThrow(new ConfigurationException("Cannot read database's config"));
    }

    public string GetConnectionString()
    {
        return ConnectionString.Replace("{{Password}}", Password);
    }
}