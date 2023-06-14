namespace VotingApp.Web.Features.Results.GetMyResults;

public class VoteResultResponse
{
    public VoteFormId FormId { get; set; } = default!;
    public string Title { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = default!;

    public IEnumerable<VoteQuestionResponse> Questions { get; set; }
        = Enumerable.Empty<VoteQuestionResponse>();
}

public class VoteQuestionResponse
{
    public string QuestionText { get; set; } = default!;
    public IEnumerable<string> SelectedValues { get; set; } = default!;
}