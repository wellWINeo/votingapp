using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VotingApp.Web.Extensions;

namespace VotingApp.Web.Infrastructure;

public class VotingAppContextDesignTimeFactory : IDesignTimeDbContextFactory<VotingAppContext>
{
    public VotingAppContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json")
            .Build();

        var connectionString = config
            .GetConnectionString("VotingDb")
            .OrThrow(new Exception("Connection string is null"));

        var options = new DbContextOptionsBuilder<VotingAppContext>()
            .UseNpgsql(connectionString)
            .Options;
        return new VotingAppContext(options);
    }
}