using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNews.Models;

namespace SportNews.Configurations
{
    public class DivisionConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.Property(d => d.Name).HasMaxLength(15);

            builder
                .HasMany(d => d.Teams)
                .WithOne(t => t.Division)
                .HasForeignKey(t => t.DivisonId);
        }
    }
}
