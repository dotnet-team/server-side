using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNews.Models;


namespace SportNews.Configurations
{
    public class MainNavigationMenuConfiguration : IEntityTypeConfiguration<MainNavigationMenu>
    {
        public void Configure(EntityTypeBuilder<MainNavigationMenu> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(25);

            builder
                .HasMany(m => m.SecondNavigationMenus)
                .WithOne(s => s.MainNavigationMenu)
                .HasForeignKey(s => s.MainNavigationMenuId);
        }
    }
}
