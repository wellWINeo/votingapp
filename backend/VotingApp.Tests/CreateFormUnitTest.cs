using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VotingApp.Web.Features.Forms.Create;
using VotingApp.Web.Infrastructure;
using Features = VotingApp.Web.Features;

namespace VotingApp.Tests;

public class CreateFormUnitTest : IDisposable
{
    private readonly VotingAppContext _context;

    public CreateFormUnitTest()
    {
        var options = new DbContextOptionsBuilder<VotingAppContext>()
            .UseInMemoryDatabase("VotingAppContext")
            .Options;
        _context = new VotingAppContext(options);
    }

    [Fact]
    public async Task CreateFormEndpoint_OnlyTitle_ShouldFail()
    {
        var ep = Factory.Create<Features.Forms.Create.Endpoint>(_context);

        var req = new Features.Forms.Create.CreateVoteFormRequest
        {
            Title = "test",
            Questions = new List<CreateVoteFormRequestQuestion>()
            {
                new CreateVoteFormRequestQuestion()
                {
                    Text = "question 1",
                    Options = new List<string>() { "a", "b" }
                }
            }
        };

        await ep.HandleAsync(req, default);

        var form = await _context.Forms
            .Include(f => f.Questions)
                .ThenInclude(q => q.Options)
            .SingleAsync();
        
        Assert.NotNull(form);
        Assert.Equal("test", form.Title);
        Assert.Single(form.Questions);
        Assert.Equal("question 1", form.Questions.ElementAt(0).Text);
        Assert.Equivalent(new string[] {"a", "b"}, form.Questions.ElementAt(0).Options);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}