using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportNews.Models
{
    public class Comment: Entity
    {
        public string Text { get; set; }

        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
