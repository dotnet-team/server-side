using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsNewsAngular.Models;


namespace SportsNewsAngular.Configurations
{
    public class SideNawConfiguration : IEntityTypeConfiguration<SideNav>
    {
        public void Configure(EntityTypeBuilder<SideNav> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(25);

            builder
                .HasMany(s => s.Teams)
                .WithOne(t => t.SideNav)
                .HasForeignKey(t => t.SideNavId);
        }
    }
}
