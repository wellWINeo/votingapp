using FastEndpoints;
using Microsoft.AspNetCore.SignalR;

namespace VotingApp.Web.Features.Comments.CommentAdded;

public sealed class CommentAddedHandler : IEventHandler<CommentAddedEvent>
{
    private readonly IHubContext<CommentsHub> _hub;

    public CommentAddedHandler(IHubContext<CommentsHub> hub)
    {
        _hub = hub;
    }

    public async Task HandleAsync(CommentAddedEvent eventModel, CancellationToken ct = new CancellationToken())
    {
        await _hub.Clients
            .Group(eventModel.FormId.ToString())
            .SendAsync("commentAdded", eventModel, ct);
    }
}