using FastEndpoints;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.AccessModes.Get;

public class Endpoint 
    : EndpointWithoutRequest<IEnumerable<AccessMode>, MultipleAccessModeMapper>
{
    public override void Configure()
    {
        Get("get");
        Group<AccessModesGroup>();
        Summary(es 
            => es.Summary = "Receive list of access modes for VoteForm's results");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var modes = Enum.GetValues<VoteResultsAccess>();
        var response = Map.FromEntity(modes);

        await SendOkAsync(response, ct);
    }
}