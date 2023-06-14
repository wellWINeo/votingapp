using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using VotingApp.Web.Extensions;
using VotingApp.Web.Infrastructure;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Results.GetMyResults;

public class Endpoint
    : EndpointWithoutRequest<
        IEnumerable<VoteResultResponse>, 
        MultipleVoteResultsResponseMapper
    >
{
    private readonly VotingAppContext _context;

    public Endpoint(VotingAppContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("/my-results");
        Group<ResultsGroup>();
        Summary(es =>
        {
            es.Summary = "Retrieve results created by user";
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var userId = User.Identity?.Name;
        var results = await _context.Set<VoteResult>()
            .Include(r => r.Form)
            .Include(r => r.QuestionResults)
                .ThenInclude(qr => qr.Question)
            .Include(r => r.QuestionResults)
                .ThenInclude(qr => qr.Values)
            .Where(r => r.CreatedBy == userId)
            .ToListAsync(ct);

        var responses = Map.FromEntity(results);

        await SendOkAsync(responses, ct);
    }
}