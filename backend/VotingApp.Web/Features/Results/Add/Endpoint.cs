using Microsoft.EntityFrameworkCore;
using VotingApp.Web.Core;
using VotingApp.Web.Extensions;
using VotingApp.Web.Infrastructure;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Results.Add;

public sealed class Endpoint : EndpointWithoutResponse<AddResultRequest, AddResultRequestMapper>
{
    private readonly VotingAppContext _context;

    public Endpoint(VotingAppContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("add");
        Group<ResultsGroup>();
        Summary(es =>
        {
            es.Summary = "Add results with selected values to form";
        });
    }

    public override async Task HandleAsync(AddResultRequest req, CancellationToken ct)
    {
        var form = await _context
            .Set<VoteForm>()
            .FirstOrDefaultAsync(f => f.Id == req.FormId, ct)
            ?? throw new Exception("Invalid form id");

        var result = Map.ToEntity(req);
        result.CreatedBy = User.GetUserName()!;

        await _context.Set<VoteResult>().AddAsync(result, ct);
        await _context.SaveChangesAsync(ct);
        
        await SendOkAsync(ct);
    }
}