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
        IAppMenu _appMenu;
        public Application(IAppMenu appMenu)
        {
            _appMenu = appMenu;
        }

        public void Run()
        {
            _appMenu.Initialize();
            _appMenu.UserChoice();
        }
    }
}
