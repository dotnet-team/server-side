using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportNews.Models
{
    public class Division: Entity
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
