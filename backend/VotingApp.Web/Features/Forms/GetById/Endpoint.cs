using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using VotingApp.Web.Extensions;
using VotingApp.Web.Infrastructure;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Forms.GetById;

public class Endpoint 
    : EndpointWithoutRequest<VoteFormWithResultResponse, VoteFormWithResultsResponseMapper>
{
    private readonly VotingAppContext _context;

    public Endpoint(VotingAppContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("get-by-id/{Id}");
        Group<FormsGroup>();
        Summary(es 
            => es.Summary = "Get voting form with result (if exists) by id"
        );
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<VoteFormId>("Id");
        var userId = User.GetUserName();
        var form = await _context.Set<VoteForm>()
            .Include(f => f.Questions)
                .ThenInclude(q => q.Options)
            .Include(f => f.Results)
                .ThenInclude(r => r.QuestionResults)
                    .ThenInclude(qr => qr.Values)
            .FirstOrDefaultAsync(f => f.Id == id, ct);
        if (form is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        form.Results = form.Results
            .Where(r => r.CreatedBy == userId)
            .Take(1)
            .ToList();

        var response = Map.FromEntity(form);
        response.IsEditable = response.CreatedBy == User.GetUserName();
        response.IsVoted = form.Results.Any(f => f.CreatedBy == userId);

        await SendOkAsync(response, ct);
    }
}