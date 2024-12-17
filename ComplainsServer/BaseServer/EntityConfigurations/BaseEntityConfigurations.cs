using Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseServer;

public class BaseEntityConfigurations<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.CreationDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
        builder.Property(e => e.Notes).HasMaxLength(1000);
    }
}
