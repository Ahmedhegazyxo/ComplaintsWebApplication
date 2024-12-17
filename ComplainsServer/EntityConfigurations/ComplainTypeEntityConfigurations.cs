using Base;
using BaseServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComplainsServer;

public class ComplainTypeEntityConfigurations : BaseEntityConfigurations<ComplainType>
{
    public override void Configure(EntityTypeBuilder<ComplainType> builder)
    {
        builder.ToTable("ComplainTypes");
        base.Configure(builder);
    }
}
