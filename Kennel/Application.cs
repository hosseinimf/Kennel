using KennelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennel
{
    public class Application : IApplication
    {

        IRegisterManager _registering;
        IMenuManager _menu;
        IAppMenu _appMenu;
        public Application(IRegisterManager registering, IMenuManager menu, IAppMenu appMenu)
        {
            _registering = registering;
            _menu = menu;
            _appMenu = appMenu;
        }

        public void Run()
        {
            _appMenu.Initialize();
            _appMenu.UserChoice();
        }

        //public void Select(List<Owner> OwnerList, List<Animal> AnimalList)
        //{
        //    bool exit = false;

        //    while(!exit)
        //    {
        //        string str = Console.ReadLine();

        //        switch (str)
        //        {
        //            case "o":
        //                _registering.RegisterOwner(OwnerList);
        //                break;

        //            case "a":
        //                _registering.RegisterAnimal(AnimalList);
        //                break;

        //            case "q":
        //                _menu.ListOwners(OwnerList);
        //                break;

        //            case "e":
        //                Console.WriteLine("exit");
        //                exit = true;
        //                break;


                    
        //        }


        //    }
        //}

       
    }
}
