namespace VotingApp.Web.Models.Entities;

public class VoteResult
{
    public VoteResultId Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public UserId CreatedBy { get; set; } = default!;

    public VoteFormId FormId { get; set; } = default!;
    public VoteForm Form { get; set; } = default!;

    public ICollection<VoteQuestionResult> QuestionResults { get; set; }
        = new List<VoteQuestionResult>();
}