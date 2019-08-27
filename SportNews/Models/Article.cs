using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportNews.Models
{
    public class Article: Entity
    {
        public string Name { get; set; }
       // public IFormFile Image { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; } 

        public string Country { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
