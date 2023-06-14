using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using VotingApp.Web.Infrastructure;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Forms.Complete;

public sealed class Endpoint : EndpointWithoutRequest
{
    private readonly VotingAppContext _context;

    public Endpoint(VotingAppContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("/complete/{Id}");
        Group<FormsGroup>();
        Summary(es => es.Summary = "Complete voting form");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<VoteFormId>("Id");

        var form = await _context
            .Set<VoteForm>()
            .FirstOrDefaultAsync(f => f.Id == id, ct);
        if (form is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        form.IsCompleted = true;
        await _context.SaveChangesAsync(ct);

        await SendOkAsync(ct);
    }
}