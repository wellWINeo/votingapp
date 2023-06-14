using FastEndpoints;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Comments.GetComments;

public class GetCommentsCommand : ICommand<IEnumerable<CommentDto>>
{
    public VoteFormId FormId { get; set; } = default!;
}

public class CommentDto
{
    public VoteFormCommentId Id { get; set; } = default!;
    public string Comment { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = default!;
    public string CreatedBy { get; set; } = default!;
    public VoteFormId FormId { get; set; } = default!;
}