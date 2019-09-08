using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsNewsAngular.Models
{
    public class Team : Entity
    {
        public string Name { get; set; }
        public int SideNavId { get; set; }

        public virtual SideNav SideNav { get; set; }
    }
}
