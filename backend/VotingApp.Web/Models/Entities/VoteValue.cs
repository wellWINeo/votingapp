namespace VotingApp.Web.Models.Entities;

public class VoteValue
{
    public VoteValueId Id { get; set; } = Guid.NewGuid();
    public string Value { get; set; } = default!;

    public VoteQuestionId QuestionId { get; set; } = default!;
    public VoteQuestion Question { get; set; } = default!;
}