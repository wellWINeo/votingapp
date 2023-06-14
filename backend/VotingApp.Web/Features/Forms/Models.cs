namespace VotingApp.Web.Features.Forms;

public class VoteFormResponse
{
    public VoteFormId Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = default!;
    public string CreatedBy { get; set; } = default!;
    public bool IsCompleted { get; set; } = default;

    public IEnumerable<VoteQuestionResponse> Questions { get; set; }
        = Enumerable.Empty<VoteQuestionResponse>();

}

public class VoteQuestionResponse
{
    public VoteQuestionId Id { get; set; }
    public string Text { get; set; } = default!;
    public bool IsMultipleAllowed { get; set; } = default!;
    public bool IsCustomAllowed { get; set; } = default!;

    public IEnumerable<VoteValueResponse> Options { get; set; }
        = Enumerable.Empty<VoteValueResponse>();
}

public class VoteValueResponse
{
    public VoteValueId Id { get; set; } = default!;
    public string Value { get; set; } = default!;
}