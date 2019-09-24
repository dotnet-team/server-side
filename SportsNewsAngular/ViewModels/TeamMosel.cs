using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsNewsAngular.ViewModels
{
    public class TeamModel
    {
        public int Id { get; set; }
        public bool IsShow { get; set; }
        public string Name { get; set; }
        public int SideNavId { get; set; }
    }
}
