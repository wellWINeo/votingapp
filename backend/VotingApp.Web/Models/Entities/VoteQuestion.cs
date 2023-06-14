namespace VotingApp.Web.Models.Entities;

public class VoteQuestion
{
    public VoteQuestionId Id { get; set; } = Guid.NewGuid();
    public string Text { get; set; } = default!;
    public bool IsMultipleAllowed { get; set; } = default!;
    public bool IsCustomAllowed { get; set; } = default!;
    
    public VoteForm Form { get; set; } = default!;
    public VoteFormId FormId { get; set; } = default!;

    public ICollection<VoteValue> Options { get; set; }
        = new List<VoteValue>();

    public ICollection<VoteQuestionResult> QuestionResults { get; set; }
        = new List<VoteQuestionResult>();
}