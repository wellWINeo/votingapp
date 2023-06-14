using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Models.Maps;

public class VoteQuestionMap : IEntityTypeConfiguration<VoteQuestion>
{
    public void Configure(EntityTypeBuilder<VoteQuestion> builder)
    {
        builder.HasKey(q => q.Id);

        builder
            .HasOne(q => q.Form)
            .WithMany(f => f.Questions);

        builder
            .HasMany(q => q.QuestionResults)
            .WithOne(qr => qr.Question);
    }
}