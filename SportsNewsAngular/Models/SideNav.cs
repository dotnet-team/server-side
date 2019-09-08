using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsNewsAngular.Models
{
    public class SideNav : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
