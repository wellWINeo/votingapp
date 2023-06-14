using Microsoft.EntityFrameworkCore;
using VotingApp.Web.Extensions;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Infrastructure;

public class VotingAppContext : DbContext, IVotingAppContext
{
    public VotingAppContext(DbContextOptions<VotingAppContext> options) 
        : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.MapEntities();
    }

    public IQueryable<VoteForm> Forms => Set<VoteForm>();
    public IQueryable<VoteFormComment> Comments => Set<VoteFormComment>();
    public IQueryable<VoteQuestion> Questions => Set<VoteQuestion>();
    public IQueryable<VoteQuestionResult> QuestionResults => Set<VoteQuestionResult>();
    public IQueryable<VoteResult> Results => Set<VoteResult>();
    public IQueryable<VoteValue> Values => Set<VoteValue>();
    public Task SaveChangesAsync() => base.SaveChangesAsync();
}