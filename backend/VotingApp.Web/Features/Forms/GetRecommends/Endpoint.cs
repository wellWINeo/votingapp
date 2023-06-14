using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using VotingApp.Web.Extensions;
using VotingApp.Web.Infrastructure;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Forms.GetRecommends;

public sealed class Endpoint 
    : EndpointWithoutRequest<
        IEnumerable<VoteFormResponse>,
        MultipleVoteFormsMapper
    >
{
    private readonly VotingAppContext _context;

    public Endpoint(VotingAppContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("get-recommends");
        Group<FormsGroup>();
        Summary(es 
            => es.Summary = "Get recommended (available) voting forms"
        );
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var user = User.GetUserName()!;

        var forms = await _context
            .Set<VoteForm>()
            .Include(f => f.Questions)
                .ThenInclude(q => q.Options)
            .Where(f => !f.IsCompleted)
            .Where(f => f.CreatedBy != user)
            .Where(f => f.Results.All(r => r.CreatedBy != user))
            .ToListAsync(ct) ?? new List<VoteForm>();

        await SendOkAsync(Map.FromEntity(forms), ct);
    }
}