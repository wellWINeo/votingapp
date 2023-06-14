using System.Collections;

namespace VotingApp.Web.Models.Entities;

public class VoteForm
{
    public VoteFormId Id { get; set; } = Guid.NewGuid();
    
    public string Title { get; set; } = default!;
    
    public string Description { get; set; } = default!;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public UserId CreatedBy { get; set; } = default!;

    public bool IsCompleted { get; set; } = false;

    public VoteResultsAccess Access { get; set; } = default!;

    public ICollection<VoteQuestion> Questions { get; set; }
        = new List<VoteQuestion>();

    public ICollection<VoteResult> Results { get; set; } 
        = new List<VoteResult>();

    public ICollection<VoteFormComment> Comments { get; set; }
        = new List<VoteFormComment>();
}