using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Owner>().As<IOwner>();
            builder.RegisterType<Menu>().As<IMenu>();
            builder.RegisterType<MenuItem>().As<IMenuItem>();
            builder.RegisterType<Animal>().As<IAnimal>();
            builder.RegisterType<RegisterManager>().As<IRegisterManager>();
            builder.RegisterType<MenuManager>().As<IMenuManager>();
            builder.RegisterType<KennelServices>().As<IKennelServices>();
            builder.RegisterType<Services>().As<IServices>();
            builder.RegisterType<AppMenu>().As<IAppMenu>();
            

            return builder.Build();
        }
    }
}
