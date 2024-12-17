using Base;
using BaseServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComplainsServer;

public class AttachmentEntityConfigurations : BaseEntityConfigurations<Attachment>
{
    public override void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.ToTable("Attachments");
        builder.Property(e => e.Content).IsRequired().HasColumnType("varbinary(max)");
        builder.Property(e => e.FileType).HasMaxLength(10);
        base.Configure(builder);
    }
}
