using FastEndpoints;
using Microsoft.AspNetCore.SignalR;
using VotingApp.Web.Extensions;
using VotingApp.Web.Features.Comments.AddComment;
using VotingApp.Web.Features.Comments.FormOpened;
using VotingApp.Web.Features.Comments.GetComments;

namespace VotingApp.Web.Features.Comments;

public class CommentsHub : Hub
{
    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }

    [HubMethodName("getComments")]
    public async Task<IEnumerable<CommentDto>> GetCommentsAsync(VoteFormId formId)
    {
        var command = new GetCommentsCommand { FormId = formId };

        return await command.ExecuteAsync();
    }

    [HubMethodName("formOpened")]
    public async Task FormOpenedAsync(VoteFormId formId)
    {
        var payloadEvent = new FormOpenedEvent
        {
            FormId = formId,
            ConnectionId = Context.ConnectionId
        };

        await payloadEvent.PublishAsync();
    }

    [HubMethodName("addComment")]
    public async Task AddCommentAsync(AddCommentDto dto)
    {
        var command = new AddCommentCommand
        {
            FormId = dto.FormId,
            Comment = dto.Comment,
            Author = Context.User?.Identity?.Name ?? string.Empty,
        };

        await command.ExecuteAsync();
    }
}