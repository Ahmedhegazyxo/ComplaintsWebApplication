using Microsoft.EntityFrameworkCore;

namespace ComplainsServer;

public class MigrationsDbContext : DbContext
{
    public MigrationsDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Data Source=192.168.200.118;Persist Security Info=True;Password=P@ssw0rdP@ssw0rd;User ID=sa;Initial Catalog=ComplaintsSystem; TrustServerCertificate=True;");
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ComplaintsSystem ;Integrated Security=True; Encrypt=False");

        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ComplainEntityConfigurations());
        modelBuilder.ApplyConfiguration(new AttachmentEntityConfigurations());
        modelBuilder.ApplyConfiguration(new ComplainAttachmentEntityConfigurations());
        modelBuilder.ApplyConfiguration(new ComplainStatusEntityConfigurations());
        modelBuilder.ApplyConfiguration(new ComplainTypeEntityConfigurations());
        modelBuilder.ApplyConfiguration(new UserEntityConfigurations());
        modelBuilder.ApplyConfiguration(new MilitaryRankEntityConfigurations());
        base.OnModelCreating(modelBuilder);
    }
}
