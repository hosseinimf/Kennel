using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public class MenuManager : IMenuManager
    {
        Services services = new Services();
        private IMenu _menu;
        private Func<int, string, IMenuItem> _menuItemCreator;

        public MenuManager(IMenu menu, Func<int, string, IMenuItem> menuItemCreator)
        {
            _menu = menu;
            _menuItemCreator = menuItemCreator;
        }


        public void CreateMenu(string title, string footer)
        {
            _menu.Title = title;
            _menu.MenuItems = new();
            _menu.Footer = footer;
        }


        public void CreateMenuItem(int choice, string itemName)
        {
            _menu.MenuItems.Add(_menuItemCreator(choice, itemName));
        }


        public void ShowMenu()
        {
            services.Print($"--------------- {_menu.Title} ----------------");

            foreach (var menuItem in _menu.MenuItems)
            {
                services.Print(String.Format(" {0,-10}  {1,-20}", $"{menuItem.Choice}", $"{menuItem.ItemName}"));
            }
             
        }


        public void ListOwners(List<IOwner> OwnerList)
        {
            services.Print("----------LIST OF OWNERS-----------");
            services.Print(String.Format(" {0,-20}  {1,-30}", $"Owner name", $"Owner Id"));
            foreach (var item in OwnerList)
            {
                services.Print(String.Format(" {0,-20}  {1,-30}", $"{item.OwnerName}", $"{item.OwnerId}"));
            }
        }


        public void ListAnimals(List<IAnimal> AnimalList)
        {
            services.Print("----------LIST OF Animals-----------");
            services.Print(String.Format(" {0,-20}  {1,-30}", $"Animal", $"Owner"));

            foreach (var item in AnimalList)
            {
                services.Print(String.Format(" {0,-20}  {1,-30}", $"{item.Name}", $"{item.OwnerName}"));
            }
        }


        public IMenu GetMenu()
        {
            return _menu;
        }







    }
}
