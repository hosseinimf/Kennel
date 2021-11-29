using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public class AppMenu : IAppMenu
    {
        private IMenuManager _menuManager;
        private IRegisterManager _registerManager;
        List<IOwner> owners = new List<IOwner>();
        List<IAnimal> animals = new List<IAnimal>();
        int[] kennelServices = new int[3] { 0, 0, 0 };


        public AppMenu(IMenuManager menuManager, IRegisterManager registerManager)
        {
            _menuManager = menuManager;
            _registerManager = registerManager;
        }

        public void Initialize()
        {
            _menuManager.CreateMenu("Kennel Menu", "Win20 2021");
            _menuManager.CreateMenuItem(1, "Register an owner");
            _menuManager.CreateMenuItem(2, "Register an animal");
            _menuManager.CreateMenuItem(3, "List all owners");
            _menuManager.CreateMenuItem(4, "List all animals");
            _menuManager.CreateMenuItem(5, "Find the owner");
            _menuManager.CreateMenuItem(6, "Report presence");
            _menuManager.CreateMenuItem(7, "List all attendants at kennel");
            _menuManager.CreateMenuItem(8, "Add a service");
            _menuManager.ShowMenu();
            _registerManager.SeedOwner(owners, animals);
        }

        public void UserChoice()
        {
            bool exit = false;

            while (!exit)
            {
                var input = Console.ReadKey(true);

                switch (input.KeyChar.ToString())
                {
                    case "1":
                        Console.Clear();
                        _menuManager.ShowMenu();
                        _registerManager.RegisterOwner(owners, animals);
                        break;

                    case "2":
                        Console.Clear();
                        _menuManager.ShowMenu();
                        _registerManager.RegisterAnimal(owners, animals);
                        break;

                    case "3":
                        Console.Clear();
                        _menuManager.ShowMenu();
                        _menuManager.ListOwners(owners, animals);
                        break;

                    case "4":
                        Console.Clear();
                        _menuManager.ShowMenu();
                        _menuManager.ListAnimals(animals);
                        break;

                    case "5":
                        Console.Clear();
                        _menuManager.ShowMenu();
                        _registerManager.FindOwner(animals, owners);
                        break;

                    case "6":
                        Console.Clear();
                        _menuManager.ShowMenu();
                        _registerManager.Report(animals);
                        break;

                    case "7":
                        Console.Clear();
                        _menuManager.ShowMenu();
                        _menuManager.ListAllAttendantAnimals(animals);
                        break;

                    case "8":
                        Console.Clear();
                        _menuManager.ShowMenu();
                        _registerManager.AddService(animals);
                        break;

                    case "e":
                        Console.Clear();
                        _menuManager.ShowMenu();
                        exit = true;
                        break;
                }
            }

        }
    }
}
