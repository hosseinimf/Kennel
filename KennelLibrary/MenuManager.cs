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
                services.Print(String.Format(" --> {0,-10}  {1,-10}", $"{menuItem.Choice}", $"{menuItem.ItemName}"));
            }

            services.Print($"--------------- {_menu.Footer} ----------------\n");

        }


        public void ListOwners(List<IOwner> OwnerList)
        {
            services.Print("---------------LIST OF OWNERS----------------");
            services.Print(String.Format(" {0,-20}  {1,-30}", $"Owner name", $"Owner Id\n"));
            foreach (var item in OwnerList)
            {
                services.Print(String.Format(" {0,-20}  {1,-30}", $"{item.OwnerName}", $"{item.OwnerId}"));
            }
        }


        public void ListAnimals(List<IAnimal> AnimalList)
        {
            services.Print("---------------LIST OF Animals----------------");
            services.Print(String.Format(" {0,-20}  {1,-30}   {2,-30}", $"Animal", $"Owner", $"Status\n"));

            foreach (var item in AnimalList)
            {
                services.Print(String.Format(" {0,-20}  {1,-30}   {2,-30}", $"{item.Name}", $"{item.OwnerName}", $"{item.ShowStatus()}"));
            }
        }


        public void ListAllAttendantAnimals(List<IAnimal> animalList)
        {
            var attendants = animalList.Where(a => a.Status == true);
            services.Print("---------------- All attendant pets at Kennel ----------------\n");
            if (attendants.Count() > 0 )
            {
                services.Print(String.Format(" {0,-20}  {1,-20}   {2,-20}", $"Animal", $"Owner", $"Status\n"));
                foreach (var item in attendants)
                {
                    services.Print(String.Format(" {0,-20}  {1,-20}   {2,-20}", $"{item.Name}", $"{item.OwnerName}", $"{item.ShowStatus()}"));
                }
            }
            else
            {
                services.Print("\n There is no pet at kennel at the moment!!!");
            }
            
        }


        public IMenu GetMenu()
        {
            return _menu;
        }

    }
}
