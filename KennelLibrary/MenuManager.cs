using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public class MenuManager : IMenuManager
    {
        private IServices s;
        private IMenu _menu;
        private Func<int, string, IMenuItem> _menuItemCreator;

        public MenuManager(IMenu menu, Func<int, string, IMenuItem> menuItemCreator, IServices services)
        {
            _menu = menu;
            _menuItemCreator = menuItemCreator;
            s = services;
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
            s.Print($"----------------- {_menu.Title} ------------------");

            foreach (var menuItem in _menu.MenuItems)
            {
                s.Print(String.Format(" --> {0,-10}  {1,-10}", $"{menuItem.Choice}", $"{menuItem.ItemName}"));
            }

            s.Print($"----------------- {_menu.Footer} ------------------\n");

        }


        public void ListOwners(List<IOwner> ownerList, List<IAnimal> animalList)
        {
            s.Print("-----------------LIST OF OWNERS------------------");
            s.Print(String.Format(" {0,-10}  {1,-20}", $"Owner name", $"Owner Id\n"));
            foreach (var item in ownerList)
            {
                s.Print("------------------------------");
                var pets = animalList.Where(a => a.OwnerId == item.OwnerId);
                s.Print(String.Format(" {0,-10}  {1,-20}", $"{item.OwnerName}", $"{item.OwnerId}"));

                s.Print(" Pets: ");
                foreach (var pet in pets)
                {
                    s.Print(" " + pet.Name + " ");
                }
                s.Print("------------------------------");
            }
        }


        public void ListAnimals(List<IAnimal> AnimalList)
        {
            s.Print("---------------LIST OF Animals----------------");
            s.Print(String.Format(" {0,-20}  {1,-30}   {2,-30}", $"Animal", $"Owner", $"Status\n"));

            foreach (var item in AnimalList)
            {
                s.Print(String.Format(" {0,-20}  {1,-30}   {2,-30}", $"{item.Name}", $"{item.OwnerName}", $"{item.ShowStatus()}"));
            }
        }


        public void ListAllAttendantAnimals(List<IAnimal> animalList)
        {
            var attendants = animalList.Where(a => a.Status == true);
            s.Print("---------------- All attendant pets at Kennel ----------------\n");
            if (attendants.Count() > 0 )
            {
                s.Print(String.Format(" {0,-20}  {1,-20}   {2,-20}", $"Animal", $"Owner", $"Status\n"));
                foreach (var item in attendants)
                {
                    s.Print(String.Format(" {0,-20}  {1,-20}   {2,-20}", $"{item.Name}", $"{item.OwnerName}", $"{item.ShowStatus()}"));
                }
            }
            else
            {
                s.Print("\n There is no pet at kennel at the moment!!!");
            }
            
        }


        public IMenu GetMenu()
        {
            return _menu;
        }

    }
}
