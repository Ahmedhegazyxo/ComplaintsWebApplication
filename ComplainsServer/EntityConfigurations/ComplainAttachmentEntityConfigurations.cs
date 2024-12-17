using Base;
using BaseServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComplainsServer;

public class ComplainAttachmentEntityConfigurations : BaseEntityConfigurations<ComplainAttachment>
{
    public override void Configure(EntityTypeBuilder<ComplainAttachment> builder)
    {
        builder.ToTable("ComplainAttachments");
        builder.HasOne(e=>e.Attachment).WithMany().HasForeignKey(e => e.AttachmentId).OnDelete(DeleteBehavior.Cascade);
        base.Configure(builder);
    }
}
