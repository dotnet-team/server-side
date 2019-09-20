using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsNewsAngular.Models
{
    public class Video : Entity
    {
        public string VideoUrl { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
        public Video()
        {
            Videos = new List<Video>();
        }
    }
}
