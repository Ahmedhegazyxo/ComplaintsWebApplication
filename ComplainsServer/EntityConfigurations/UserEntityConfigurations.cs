using Base;
using BaseServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComplainsServer;

public class UserEntityConfigurations : BaseEntityConfigurations<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasIndex(e=>e.UserName).IsUnique();
        
        base.Configure(builder);
    }
}
 