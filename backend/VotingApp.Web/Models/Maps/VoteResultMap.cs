using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Models.Maps;

public class VoteResultMap : IEntityTypeConfiguration<VoteResult>
{
    public void Configure(EntityTypeBuilder<VoteResult> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasIndex(r => r.CreatedBy);
        
        builder
            .HasOne(r => r.Form)
            .WithMany(f => f.Results);

        builder
            .HasMany(r => r.QuestionResults)
            .WithOne(qr => qr.Result);
    }
}