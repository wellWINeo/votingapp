using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Models.Maps;

public class VoteQuestionResultMap : IEntityTypeConfiguration<VoteQuestionResult>
{
    public void Configure(EntityTypeBuilder<VoteQuestionResult> builder)
    {
        builder.HasKey(qr => qr.Id);

        builder
            .HasOne(qr => qr.Question)
            .WithMany(q => q.QuestionResults)
            .HasForeignKey(qr => qr.QuestionId);

        builder
            .HasMany(qr => qr.Values)
            .WithMany();
    }
}