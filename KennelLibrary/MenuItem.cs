using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public class MenuItem : IMenuItem
    {
        public int Choice { get; set; }
        public string ItemName { get; set; }
        public Action Action { get; set; }


        public MenuItem(int choice, string itemName)
        {
            Choice = choice;
            ItemName = itemName;
            //Action = action;
        }
    }
}
