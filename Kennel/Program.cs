using Autofac;
using KennelLibrary;
using System;
using System.Collections.Generic;

namespace Kennel
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                
                app.Run();              
            }

            Console.ReadLine();
        }
    }
}
