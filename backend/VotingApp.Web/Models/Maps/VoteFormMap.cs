using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Models.Maps;

public class VoteFormMap : IEntityTypeConfiguration<VoteForm>
{
    public void Configure(EntityTypeBuilder<VoteForm> builder)
    {
        builder.HasKey(f => f.Id);

        builder
            .HasMany(f => f.Questions)
            .WithOne(q => q.Form);

        builder
            .HasMany(f => f.Results)
            .WithOne(r => r.Form);
    }
}