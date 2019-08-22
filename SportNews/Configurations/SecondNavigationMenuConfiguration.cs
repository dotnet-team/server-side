using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNews.Models;

namespace SportNews.Configurations
{
    public class SecondNavigationMenuConfiguration : IEntityTypeConfiguration<SecondNavigationMenu>
    {
        public void Configure(EntityTypeBuilder<SecondNavigationMenu> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(25);

        }
    }
}
