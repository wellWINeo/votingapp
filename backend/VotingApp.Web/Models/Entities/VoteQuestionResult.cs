namespace VotingApp.Web.Models.Entities;

public class VoteQuestionResult
{
    public VoteQuestionResultId Id { get; set; } = Guid.NewGuid();
    
    public VoteQuestionId QuestionId { get; set; } = default!;
    public VoteQuestion Question { get; set; } = default!;

    public VoteResultId ResultId { get; set; } = default!;
    public VoteResult Result { get; set; } = default!;

    public ICollection<VoteValue> Values { get; set; }
        = new List<VoteValue>();
}