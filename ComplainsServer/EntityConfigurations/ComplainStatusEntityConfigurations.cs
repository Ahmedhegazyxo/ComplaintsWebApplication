using Base;
using BaseServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComplainsServer;

public class ComplainStatusEntityConfigurations : BaseEntityConfigurations<ComplainStatus>
{
    public override void Configure(EntityTypeBuilder<ComplainStatus> builder)
    {
        builder.ToTable("ComplainStatus");
        base.Configure(builder);
    }
}
