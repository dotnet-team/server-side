using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNews.Models;

namespace SportNews.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(25);

            builder
                .HasMany(c => c.CategoryUsers)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);

            builder
                .HasMany(c => c.Divisions)
                .WithOne(d => d.Category)
                .HasForeignKey(d => d.CategoryId);
        }
    }
}
