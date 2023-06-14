using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Models.Maps;

public class VoteValueMap : IEntityTypeConfiguration<VoteValue>
{
    public void Configure(EntityTypeBuilder<VoteValue> builder)
    {
        builder.HasKey(v => v.Id);

        builder
            .HasOne(v => v.Question)
            .WithMany(q => q.Options)
            .HasForeignKey(v => v.QuestionId);
    }
}