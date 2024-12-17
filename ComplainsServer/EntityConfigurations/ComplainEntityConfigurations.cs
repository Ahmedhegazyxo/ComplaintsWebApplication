using Base;
using BaseServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComplainsServer;
public class ComplainEntityConfigurations : BaseEntityConfigurations<Complain>
{
    public override void Configure(EntityTypeBuilder<Complain> builder)
    {
        builder.ToTable("Complains");
        builder.Property(e => e.ComplainBody).HasColumnType("nvarchar(max)");
        builder.Property(e => e.ComplainReply).HasColumnType("nvarchar(max)");
        builder.Property(e => e.NationalId).HasMaxLength(14);
        builder.HasOne(e=>e.ComplainStatus).WithMany().HasForeignKey(e=>e.ComplainStatusId);
        builder.HasOne(e=>e.MilitaryRank).WithMany().HasForeignKey(e=>e.MilitaryRankId);
        builder.HasOne(e=>e.ComplainType).WithMany().HasForeignKey(e=>e.ComplainTypeId);
        builder.HasMany(e=>e.ComplainAttachments).WithOne().HasForeignKey(e=>e.ComplainId).OnDelete(DeleteBehavior.Cascade);
        base.Configure(builder);
    }
}