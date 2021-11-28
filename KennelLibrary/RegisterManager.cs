using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public class RegisterManager : IRegisterManager
    {
        Services services = new Services();
        

        public void RegisterOwner(List<IOwner> ownerList)
        {
            IOwner owner = new Owner();
           
            services.Print("Please enter your name:");
            owner.OwnerName = services.GetStringValue();

            while (!services.CheckInput(owner.OwnerName))
            {
                services.Print("Please enter your name correctly!!!");
                owner.OwnerName = services.GetStringValue();
            }

            ownerList.Add(owner);
        }


        public void RegisterAnimal(List<IAnimal> animalList)
        {
            IAnimal animal = new Animal();

            services.Print("Please enter pets name: ");
            animal.Name = services.GetStringValue();

            while (!services.CheckInput(animal.Name))
            {
                services.Print("Please enter the name correctly!!!");
                animal.Name = services.GetStringValue();
            }

            services.Print("Please enter the owners name: ");
            animal.OwnerName = services.GetStringValue();

            while (!services.CheckInput(animal.OwnerName))
            {
                services.Print("Please enter the name correctly!!!");
                animal.OwnerName = services.GetStringValue();
            }

            animalList.Add(animal);
        }

        

    }
}
