using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public class RegisterManager : IRegisterManager
    {
        private IServices s;
        IKennelServices _kennelServices;

        public RegisterManager(IKennelServices kennelServices, IServices services)
        {
            _kennelServices = kennelServices;
            s = services;
        }
        

        public void RegisterOwner(List<IOwner> ownerList, List<IAnimal> animalList)
        {
            IOwner owner = new Owner();
            
            
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
                IAnimal pet = new Animal();
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
            IAnimal animal = new Animal();
            IOwner owner = new Owner();

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


        public void Report(List<IAnimal> animalList)
        {
            IAnimal pet = new Animal();
           
            s.Print("\n Enter your pets name: ");
            string str = s.GetStringValue().ToLower();

            var index = animalList.IndexOf(animalList.Where(a => a.Name.ToLower() == str).FirstOrDefault());

            if (index > -1)
            {
                s.Print("\n Press 'l or L' to leave the pet at Kennel");
                s.Print(" Press 'p or P' to pich up the pet from Kennel");
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


        public void SeedOwner(List<IOwner> ownerList, List<IAnimal> animalList)
        {
            ownerList.Add(new Owner { OwnerId = 101, OwnerName = "Anders", NumberOfAnimals = 1 });
            ownerList.Add(new Owner { OwnerId = 102, OwnerName = "Peter", NumberOfAnimals = 1 });
            ownerList.Add(new Owner { OwnerId = 103, OwnerName = "Johan", NumberOfAnimals = 1 });

            animalList.Add(new Animal { AnimalId = 1, Name = "Piti", OwnerName = "Anders", OwnerId = 101, Status = false, Services = new int[3] { 0, 0, 0 } });
            animalList.Add(new Animal { AnimalId = 2, Name = "siti", OwnerName = "Peter", OwnerId = 102, Status = false, Services = new int[3] { 0, 0, 0 } });
            animalList.Add(new Animal { AnimalId = 3, Name = "lili", OwnerName = "Linda", OwnerId = 103, Status = false, Services = new int[3] { 0, 0, 0 } });
        }


        public void AddService(List<IAnimal> animals)
        {
            var pet = GetAnimal(animals);

            if (pet is not null)
            {
                //pet.Services = new int[3];
                bool exit = false;
                s.Print(" Select the service: ");
                s.Print(" w: washing   t: Claw Trimming    g: Pet Grooming    e: exit");
                var input = Console.ReadKey(true);

                while (!exit)
                {
                    if (input.KeyChar.ToString().ToLower() == "w")
                    {
                        if (_kennelServices.AddWashing(pet))
                        {
                            s.Print($"a washing service is added for pet name: {pet.Name}.");
                        }
                        animals[animals.IndexOf(pet)].Services[0] = pet.Services[0];
                        exit = true;
                    }
                    else if (input.KeyChar.ToString().ToLower() == "t")
                    {
                        if (_kennelServices.AddClawTrimming(pet))
                        {
                            s.Print($"a trimming service is added for pet name: {pet.Name}.");
                        }
                        animals[animals.IndexOf(pet)].Services[1] = pet.Services[1];
                        exit = true;
                    }
                    else if (input.KeyChar.ToString().ToLower() == "g")
                    {
                        if (_kennelServices.AddPetGrooming(pet))
                        {
                            s.Print($"a grooming service is added for pet name: {pet.Name}.");
                        }
                        animals[animals.IndexOf(pet)].Services[2] = pet.Services[2];
                        exit = true;
                    }
                    else if (input.KeyChar.ToString().ToLower() == "e")
                    {                       
                        exit = true;
                    }
                    else
                    {
                        s.Print("Choose one of  w: washing   t: Claw Trimming    g: Pet Grooming    e: exit");
                        input = Console.ReadKey(true);
                    }
                }
            }
            else
            {
                s.Print("There is no pet with this name.");
            }
            
        }


        public IAnimal GetAnimal(List<IAnimal> animals)
        {
            s.Print("Enter the pets name: ");
            string str = s.GetStringValue().ToLower();
            var index = animals.IndexOf(animals.Where(a => a.Name.ToLower() == str).FirstOrDefault());

            if (index > -1)
                return animals[index];
            else
                return null;
        }



    }
}
