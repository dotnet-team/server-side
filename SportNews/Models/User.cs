using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportNews.Models
{
    public class User: IdentityUser
    {
        public virtual ICollection<CategoryUser> CategoryUsers { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
