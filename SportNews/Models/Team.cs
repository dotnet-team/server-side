using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportNews.Models
{
    public class Team : Entity
    {
        public string Name { get; set; }

        public int DivisonId { get; set; }
        public virtual Division Division { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
