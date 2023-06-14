namespace VotingApp.Web.Features.Results.Add;

public class AddResultRequest
{
    public VoteFormId FormId { get; set; }

    public IEnumerable<AddResultQuestionRequest> Questions { get; set; }
        = Enumerable.Empty<AddResultQuestionRequest>();
}

public class AddResultQuestionRequest
{
    public VoteQuestionId QuestionId { get; set; } = default!;
    public IEnumerable<VoteValueId> Values { get; set; }
}