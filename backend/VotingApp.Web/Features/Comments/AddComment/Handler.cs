using FastEndpoints;
using VotingApp.Web.Features.Comments.CommentAdded;
using VotingApp.Web.Infrastructure;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Comments.AddComment;

public sealed class Handler : ICommandHandler<AddCommentCommand>
{
    private readonly VotingAppContext _context;

    public Handler(VotingAppContext context)
    {
        _context = context;
    }

    public async Task ExecuteAsync(AddCommentCommand command, CancellationToken ct = new())
    {
        var comment = new VoteFormComment
        {
            Comment = command.Comment,
            CreatedBy = command.Author,
            FormId = command.FormId,
        };

        await _context.Set<VoteFormComment>().AddAsync(comment, ct);
        await _context.SaveChangesAsync(ct);

        var eventModel = new CommentAddedEvent
        {
            FormId = comment.FormId,
            Comment = comment.Comment,
            CreatedBy = comment.CreatedBy,
            CreatedAt = comment.CreatedAt
        };

        await eventModel.PublishAsync(cancellation: ct);
    }
}