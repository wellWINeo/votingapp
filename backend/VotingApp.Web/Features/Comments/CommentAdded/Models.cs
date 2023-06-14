using FastEndpoints;

namespace VotingApp.Web.Features.Comments.CommentAdded;

public class CommentAddedEvent : IEvent
{
    public VoteFormId FormId { get; set; } = default!;
    public string Comment { get; set; } = default!;
    public string CreatedBy { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = default!;
}