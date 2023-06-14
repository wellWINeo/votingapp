namespace VotingApp.Web.Features.Results.GetResults;

public class ResultsStatistic
{
    public VoteQuestionId QuestionId { get; set; } = default!;
    public string QuestionText { get; set; } = default!;

    public IEnumerable<ResultsQuestionAnswerStatistic> Statistics { get; set; }
        = Enumerable.Empty<ResultsQuestionAnswerStatistic>();

    public IEnumerable<ResultsQuestionAnswer> Answers { get; set; }
        = Enumerable.Empty<ResultsQuestionAnswer>();
}

public class ResultsQuestionAnswer
{
    public string? Login { get; set; } = null!;

    public IEnumerable<string> Values { get; set; }
        = Enumerable.Empty<string>();
}

public class ResultsQuestionAnswerStatistic
{
    public string DisplayText { get; set; } = default!;
    public int Count { get; set; } = default!;
}