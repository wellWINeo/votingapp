using FastEndpoints;

namespace VotingApp.Web.Features.Comments.AddComment;

public class AddCommentCommand : ICommand
{
    public VoteFormId FormId { get; set; } = default!;
    public string Comment { get; set; } = default!;
    public string Author { get; set; } = default!;
}