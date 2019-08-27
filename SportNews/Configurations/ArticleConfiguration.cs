using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNews.Models;

namespace SportNews.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(a => a.Name).HasMaxLength(25);
            builder.Property(a => a.Title).HasMaxLength(45);
            builder.Property(a => a.Text).HasMaxLength(255);

            builder
                .HasMany(a => a.Comments)
                .WithOne(c => c.Article)
                .HasForeignKey(c => c.ArticleId);

        }
    }
}
