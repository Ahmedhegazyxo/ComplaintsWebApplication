using Base;
using BaseServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComplainsServer;

public class MilitaryRankEntityConfigurations : BaseEntityConfigurations<MilitaryRank>
{
    public override void Configure(EntityTypeBuilder<MilitaryRank> builder)
    {
        builder.ToTable("MilitaryRanks");
        builder.Property(e => e.Name).HasMaxLength(20);
        builder.HasIndex(e => e.Name).IsUnique();
        builder.HasIndex(e=> e.RankPriority).IsUnique();
        base.Configure(builder);
    }
}