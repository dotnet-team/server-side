using System.Collections.Generic;

namespace SportNews.Models
{
    public class MainNavigationMenu: Entity
    {
        public string Name { get; set; }
        public int Order { get; set; }

        public virtual ICollection<SecondNavigationMenu> SecondNavigationMenus { get; set; }
    }
}
