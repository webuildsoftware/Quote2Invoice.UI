using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Quote2Invoice.UI.Data.Entities
{
  public class SessionMapping : IEntityTypeConfiguration<Session>
  {
    public void Configure(EntityTypeBuilder<Session> builder)
    {
      builder.ToTable("UISessions");

      builder.HasKey("SessionId");
    }
  }
}
