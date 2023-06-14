using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Comments;

public class AddCommentDto
{
    public string Comment { get; set; } = default!;
    public VoteFormId FormId { get; set; } = default!;
}