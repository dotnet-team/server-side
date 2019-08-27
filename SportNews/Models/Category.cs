using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportNews.Models
{
    public class Category: Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Division> Divisions { get; set; }

        public virtual ICollection<CategoryUser> CategoryUsers { get; set; }
    }
}
