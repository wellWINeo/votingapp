using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Forms.GetById;

public class VoteFormWithResultResponse
{
    public VoteFormId FormId { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = default!;
    public string CreatedBy { get; set; } = default!;
    public bool IsCompleted { get; set; } = default!;
    public bool IsVoted { get; set; } = default!;
    public bool IsEditable { get; set; } = default!;
    public IEnumerable<VoteQuestionWithResultResponse> Questions { get; set; }
        = Enumerable.Empty<VoteQuestionWithResultResponse>();
}

public class VoteQuestionWithResultResponse
{
    public VoteQuestionId QuestionId { get; set; }
    public string Text { get; set; } = default!;
    public bool IsMultipleAllowed { get; set; } = default!;
    public bool IsCustomAllowed { get; set; } = default!;
    
    public IEnumerable<VoteValueResponse> Options { get; set; }
        = Enumerable.Empty<VoteValueResponse>();

    public IEnumerable<VoteValueResponse> SelectedOptions { get; set; }
        = Enumerable.Empty<VoteValueResponse>();
}

public class VoteResultResponse
{
    public VoteResultId Id { get; set; } = default!;
    public UserId CreatedBy { get; set; } = default;
    public IEnumerable<VoteValueResponse> Values { get; set; }
        = Enumerable.Empty<VoteValueResponse>();
}