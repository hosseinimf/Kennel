﻿using System;
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
            _menuManager.ShowMenu();
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
                        _registerManager.RegisterOwner(owners);
                        break;

                    case "2":
                        Console.Clear();
                        _menuManager.ShowMenu();
                        _registerManager.RegisterAnimal(animals);
                        break;

                    case "3":
                        Console.Clear();
                        _menuManager.ShowMenu();
                        _menuManager.ListOwners(owners);
                        break;

                    case "4":
                        Console.Clear();
                        _menuManager.ShowMenu();
                        _menuManager.ListAnimals(animals);
                        break;
                }
            }

        }




        //public void UserChoice()
        //{
        //    while (true)
        //    {
        //        var input = Console.ReadKey(true);

        //        foreach (var menuItem in _menuManager.GetMenu().MenuItems)
        //        {
        //            if (input.KeyChar.ToString() == "1")
        //            {
        //                Console.Clear();
        //                _menuManager.ShowMenu();
        //                _registerManager.RegisterOwner(owners);
        //            }
        //            else if (input.KeyChar.ToString() == "2")
        //            {
        //                Console.Clear();
        //                _menuManager.ShowMenu();
        //                _registerManager.RegisterAnimal(animals);
        //            }
        //            else if (input.KeyChar.ToString() == "3")
        //            {

        //                _menuManager.ListOwners(owners);
        //            }
        //            else if (input.KeyChar == 'e')
        //            {
        //                Environment.Exit(0);
        //            }
        //        }
        //    }

        //}
    }
}
