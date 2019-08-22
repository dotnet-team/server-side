using System.Collections.Generic;

namespace SportNews.Models
{
    public class SecondNavigationMenu: Entity
    {
        public string Name { get; set; }
        public int Order { get; set; }

        public int MainNavigationMenuId { get; set; }
        public virtual MainNavigationMenu MainNavigationMenu { get; set; }

    }
}
