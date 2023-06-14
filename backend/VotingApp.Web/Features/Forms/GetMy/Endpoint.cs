using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using VotingApp.Web.Extensions;
using VotingApp.Web.Infrastructure;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Forms.GetMy;

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
        Get("get-my");
        Group<FormsGroup>();
        Summary(es => es.Summary = "Receive voting forms created by user");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var user = User.GetUserName();
        var forms = await _context
            .Set<VoteForm>()
            .Include(f => f.Questions)
                .ThenInclude(q => q.Options)
            .Where(f => f.CreatedBy == user)
            .ToListAsync(ct);
        forms ??= new List<VoteForm>();

        await SendOkAsync(Map.FromEntity(forms), ct);
    }
}