using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Forms.Create;

public class CreateVoteFormRequest
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; } = default!;
    public VoteResultsAccess Access { get; set; } = VoteResultsAccess.Transparent;

    public ICollection<CreateVoteFormRequestQuestion> Questions { get; set; }
        = new List<CreateVoteFormRequestQuestion>();
}

public class CreateVoteFormRequestQuestion
{
    public string Text { get; set; } = default!;
    public bool IsMultipleAllowed { get; set; } = false;
    public bool IsCustomAllowed { get; set; } = false;

    public ICollection<string> Options { get; set; }
        = new List<string>();
}

public class CreateVoteFormResponse { }