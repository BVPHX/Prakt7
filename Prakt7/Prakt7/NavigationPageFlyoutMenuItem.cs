using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prakt7
{
    public class NavigationPageFlyoutMenuItem
    {
        public NavigationPageFlyoutMenuItem()
        {
            TargetType = typeof(NavigationPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}