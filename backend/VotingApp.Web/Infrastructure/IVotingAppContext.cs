using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Infrastructure;

public interface IVotingAppContext
{
    IQueryable<VoteForm> Forms { get; }
    IQueryable<VoteFormComment> Comments { get; }
    IQueryable<VoteQuestion> Questions { get; }
    IQueryable<VoteQuestionResult> QuestionResults { get; }
    IQueryable<VoteResult> Results { get; }
    IQueryable<VoteValue> Values { get; }
    Task SaveChangesAsync();
}