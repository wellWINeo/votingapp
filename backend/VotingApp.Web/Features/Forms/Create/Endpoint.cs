using FastEndpoints;
using VotingApp.Web.Extensions;
using VotingApp.Web.Infrastructure;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Forms.Create;

public sealed class Endpoint
    : Endpoint<
        CreateVoteFormRequest,
        CreateVoteFormResponse,
        CreateVoteFormRequestMapper
    >
{
    private readonly VotingAppContext _context;

    public Endpoint(VotingAppContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("create");
        Group<FormsGroup>();
    }

    public override async Task HandleAsync(CreateVoteFormRequest req, CancellationToken ct)
    {
        var form = Map.ToEntity(req);
        form.CreatedBy = User.GetUserName()!;

        _context.Set<VoteForm>().Add(form);
        await _context.SaveChangesAsync(ct);

        await SendOkAsync(ct);
    }
}