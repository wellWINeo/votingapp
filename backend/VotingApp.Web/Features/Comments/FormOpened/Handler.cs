using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using Microsoft.AspNetCore.SignalR;

namespace VotingApp.Web.Features.Comments.FormOpened;

public sealed class Handler : IEventHandler<FormOpenedEvent>
{
    private readonly IHubContext<CommentsHub> _hub;

    public Handler(IHubContext<CommentsHub> hub)
    {
        _hub = hub;
    }

    public async Task HandleAsync(FormOpenedEvent eventModel, CancellationToken ct = new())
    {
        await _hub.Groups.AddToGroupAsync(
            eventModel.ConnectionId, 
            eventModel.FormId.ToString(), 
            ct);
    }
}