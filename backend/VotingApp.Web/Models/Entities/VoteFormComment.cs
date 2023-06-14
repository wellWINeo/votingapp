namespace VotingApp.Web.Models.Entities;

public class VoteFormComment
{
    public VoteFormCommentId Id { get; set; } = Guid.NewGuid();
    public string Comment { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = default!;

    public VoteFormId FormId { get; set; } = default!;
    public VoteForm Form { get; set; } = default!;
}