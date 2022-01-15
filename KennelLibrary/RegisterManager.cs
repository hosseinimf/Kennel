using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public class RegisterManager : IRegisterManager
    {
        private readonly IServices s;
        private readonly IKennelServices _kennelServices;


        public RegisterManager(IKennelServices kennelServices, IServices services)
        {
            _kennelServices = kennelServices;
            s = services;
        }
        

        public void RegisterOwner(List<IOwner> ownerList, List<IAnimal> animalList)
        {
            var container = ContainerConfig.Configure();
            var owner = container.Resolve<IOwner>();

            int num;
           
            s.Print("Please enter your name:");
            owner.OwnerName = s.GetStringValue();
            owner.OwnerId = s.IdIncrement(ownerList);

            s.Print("How many pets do you want to register? (max 3 pets!!!)");
            num = s.GetIntValue();

            while (num > 3)
            {
                s.Print("max 3 pets!!!");
                num = s.GetIntValue();
                owner.NumberOfAnimals = num;
            }

            for (int i = 0; i < num; i++)
            {
                var pet = container.Resolve<IAnimal>();
                s.Print("Please enter your pet name:");
                pet.Name = s.GetStringValue();
                pet.OwnerName = owner.OwnerName;
                pet.Status = false;
                pet.OwnerId = owner.OwnerId;
                pet.Services = new int[3] { 0, 0, 0 };
                animalList.Add(pet);
            }
            ownerList.Add(owner);
        }


        public void RegisterAnimal(List<IOwner> ownerList, List<IAnimal> animalList)
        {
            var container = ContainerConfig.Configure();
            var animal = container.Resolve<IAnimal>();
            var owner = container.Resolve<IOwner>();

            
            s.Print("Please enter pets name: ");
            animal.Name = s.GetStringValue();

            s.Print("Please enter the owners name: ");
            animal.OwnerName = s.GetStringValue();
            animal.Status = false;
            animal.Services = new int[3] { 0, 0, 0 };
            owner.OwnerName = animal.OwnerName;
            owner.OwnerId = s.IdIncrement(ownerList);
            animal.OwnerId = owner.OwnerId;
            
            animalList.Add(animal);
            ownerList.Add(owner);
        }


        public IOwner FindOwner(List<IAnimal> animals, List<IOwner> owners)
        {
            IAnimal pet = new Animal();
            IOwner owner = new Owner();

            s.Print("Enter your pets name: ");
            string str = s.GetStringValue();

            pet = animals.Where(a => a.Name == str).FirstOrDefault();

            if (pet is not null)
            {
                owner = owners.Where(o => o.OwnerName == pet.OwnerName).FirstOrDefault();
                if (owner is not null)
                {
                    s.OwnerInfo(owner);
                    return owner;     
                }
                else
                {
                    return null;
                }
                     
            }
            else
            {
                s.Print("There is no pet with this name.");
                return null;               
            }
        }


        public void RegisterAttendancy(List<IAnimal> animalList)
        {
            
            s.Print("\n Enter your pets name: ");
            string str = s.GetStringValue().ToLower();

            var index = animalList.IndexOf(animalList.Where(a => a.Name.ToLower() == str).FirstOrDefault());

            if (index > -1)
            {
                s.Print("\n Press 'l or L' to leave the pet at Kennel");
                s.Print(" Press 'p or P' to pick up the pet from Kennel");
                var input = Console.ReadKey(true);

                while (!(input.KeyChar.ToString().ToLower() == "l") == !(input.KeyChar.ToString().ToLower() == "p"))
                {
                    s.Print("\nPress 'l or L' to leave the pet at Kennel");
                    s.Print("Press 'p or P' to pich up the pet from Kennel");
                    input = Console.ReadKey(true);
                }

                if (input.KeyChar.ToString().ToLower() == "l")
                {
                    animalList[index].Status = true;
                    //pet.Status = true;
                    s.Print($"\n--<<{animalList[index].Name} is leaved at Kennel by {animalList[index].OwnerName}.>>--");
                }

                if (input.KeyChar.ToString().ToLower() == "p")
                {
                    animalList[index].Status = false;
                    //pet.Status = false;
                    s.Print($"\n--<<{animalList[index].Name} is picked up by {animalList[index].OwnerName}.>>--");
                    _kennelServices.GetReceipt(animalList[index]);
                }
            }
            else
            {
                s.Print("´There is no pet with this name.");
            }
            

        }

    }
}
