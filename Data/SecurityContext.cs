using Microsoft.EntityFrameworkCore;
using Quote2Invoice.UI.Data.Entities;

namespace Quote2Invoice.UI.Data
{
  public class SecurityContext : DbContext
  {
    public DbSet<Session> Sessions { get; set; }

    public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfiguration(new SessionMapping());
    }
  }
}
