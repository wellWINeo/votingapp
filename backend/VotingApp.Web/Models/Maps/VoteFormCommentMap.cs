using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Models.Maps;

public class VoteFormCommentMap : IEntityTypeConfiguration<VoteFormComment>
{
    public void Configure(EntityTypeBuilder<VoteFormComment> builder)
    {
        builder.HasKey(c => c.Id);
        builder
            .Property(c => c.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);

        builder
            .HasOne(c => c.Form)
            .WithMany(f => f.Comments)
            .HasForeignKey(c => c.FormId);
    }
}