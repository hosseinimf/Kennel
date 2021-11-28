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
        

        public void RegisterOwner(List<IOwner> ownerList, List<IAnimal> animalList)
        {
            IOwner owner = new Owner();
            
            int num;
           
            services.Print("Please enter your name:");
            owner.OwnerName = services.GetStringValue();


            services.Print("How many pets do you want to register? (max 3 pets!!!)");
            num = services.GetIntValue();

            for (int i = 0; i < num; i++)
            {
                IAnimal pet = new Animal();
                services.Print("Please enter your pet name:");
                pet.Name = services.GetStringValue();
                pet.OwnerName = owner.OwnerName;
                pet.Status = false;
                animalList.Add(pet);
            }
            ownerList.Add(owner);
        }


        public void RegisterAnimal(List<IOwner> ownerList, List<IAnimal> animalList)
        {
            IAnimal animal = new Animal();
            IOwner owner = new Owner();

            services.Print("Please enter pets name: ");
            animal.Name = services.GetStringValue();

            services.Print("Please enter the owners name: ");
            animal.OwnerName = services.GetStringValue();
            animal.Status = false;
            owner.OwnerName = animal.OwnerName;

            animalList.Add(animal);
            ownerList.Add(owner);
        }


        public IOwner FindOwner(List<IAnimal> animals, List<IOwner> owners)
        {
            IAnimal pet = new Animal();
            IOwner owner = new Owner();

            services.Print("Enter your pets name: ");
            string str = services.GetStringValue();

            pet = animals.Where(a => a.Name == str).FirstOrDefault();

            if (pet is not null)
            {
                owner = owners.Where(o => o.OwnerName == pet.OwnerName).FirstOrDefault();
                if (owner is not null)
                {
                    services.OwnerInfo(owner);
                    return owner;     
                }
                else
                {
                    return null;
                }
                     
            }
            else
            {
                services.Print("There is no pet with this name.");
                return null;               
            }
        }


        public void Report(List<IAnimal> animalList)
        {
            IAnimal pet = new Animal();
           
            services.Print("Enter your pets name: ");
            string str = services.GetStringValue();

            pet = animalList.Where(a => a.Name == str).FirstOrDefault();

            services.Print("Press 'l or L' to leave the pet at Kennel");
            services.Print("Press 'p or P' to pich up the pet from Kennel");
            var input = Console.ReadKey(true);

            while (!(input.KeyChar.ToString().ToLower() == "l" || input.KeyChar.ToString().ToLower() == "p"))
            {
                services.Print("Press 'l or L' to leave the pet at Kennel");
                services.Print("Press 'p or P' to pich up the pet from Kennel");
                input = Console.ReadKey(true);

                if (input.KeyChar.ToString().ToLower() == "l")
                {
                    pet.Status = true;
                }
                if (input.KeyChar.ToString().ToLower() == "p")
                {
                    pet.Status = false;
                }
            }

            //do
            //{
            //    services.Print("Press 'l or L' to leave the pet at Kennel");
            //    services.Print("Press 'p or P' to pich up the pet from Kennel");
            //    input = Console.ReadKey(true);

            //    if (input.KeyChar.ToString().ToLower() == "l")
            //    {
            //        pet.Status = true;
            //    }
            //    if (input.KeyChar.ToString().ToLower() == "p")
            //    {
            //        pet.Status = false;
            //    }
            //} while (!(input.KeyChar.ToString().ToLower() == "l" || input.KeyChar.ToString().ToLower() == "p"));

            
            
        }



    }
}
