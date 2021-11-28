using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public class Menu : IMenu
    {
        public string Title { get; set; }
        public List<IMenuItem> MenuItems { get; set; }
        public string Footer { get; set; }
    }
}
