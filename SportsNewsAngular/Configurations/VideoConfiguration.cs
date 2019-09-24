using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsNewsAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsNewsAngular.Configurations
{
    public class VideoConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder) { }
    }
          
}
