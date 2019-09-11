using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsNewsAngular.ViewModels
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsShow { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public string Country { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }

    }
}
