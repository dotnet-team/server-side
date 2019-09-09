using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsNewsAngular.Models
{
    public class Article : Entity
    {
        public string Name { get; set; }
        // public IFormFile Image { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public string Country { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
