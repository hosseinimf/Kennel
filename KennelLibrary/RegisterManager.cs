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
        IKennelServices _kennelServices;

        public RegisterManager(IKennelServices kennelServices)
        {
            _kennelServices = kennelServices;
        }
        

        public void RegisterOwner(List<IOwner> ownerList, List<IAnimal> animalList)
        {
            IOwner owner = new Owner();
            
            int num;
           
            services.Print("Please enter your name:");
            owner.OwnerName = services.GetStringValue();


            services.Print("How many pets do you want to register? (max 3 pets!!!)");
            num = services.GetIntValue();

            while (num > 3)
            {
                services.Print("max 3 pets!!!");
                num = services.GetIntValue();
            }

            for (int i = 0; i < num; i++)
            {
                IAnimal pet = new Animal();
                services.Print("Please enter your pet name:");
                pet.Name = services.GetStringValue();
                pet.OwnerName = owner.OwnerName;
                pet.Status = false;
                pet.Services = new int[3] { 0, 0, 0 };
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
            animal.Services = new int[3] { 0, 0, 0 };
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
           
            services.Print("\n Enter your pets name: ");
            string str = services.GetStringValue().ToLower();

            var index = animalList.IndexOf(animalList.Where(a => a.Name.ToLower() == str).FirstOrDefault());

            if (index > -1)
            {
                services.Print("\n Press 'l or L' to leave the pet at Kennel");
                services.Print(" Press 'p or P' to pich up the pet from Kennel");
                var input = Console.ReadKey(true);

                while (!(input.KeyChar.ToString().ToLower() == "l") == !(input.KeyChar.ToString().ToLower() == "p"))
                {
                    services.Print("\nPress 'l or L' to leave the pet at Kennel");
                    services.Print("Press 'p or P' to pich up the pet from Kennel");
                    input = Console.ReadKey(true);
                }

                if (input.KeyChar.ToString().ToLower() == "l")
                {
                    animalList[index].Status = true;
                    //pet.Status = true;
                    services.Print($"\n--<<{animalList[index].Name} is leaved at Kennel by {animalList[index].OwnerName}.>>--");
                }

                if (input.KeyChar.ToString().ToLower() == "p")
                {
                    animalList[index].Status = false;
                    //pet.Status = false;
                    services.Print($"\n--<<{animalList[index].Name} is picked up by {animalList[index].OwnerName}.>>--");
                    _kennelServices.GetReceipt(animalList[index]);
                }
            }
            else
            {
                services.Print("´There is no pet with this name.");
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
                Console.WriteLine(" Select the service: ");
                Console.WriteLine(" w: washing   t: Claw Trimming    g: Pet Grooming    e: exit");
                var input = Console.ReadKey(true);

                while (!exit)
                {
                    if (input.KeyChar.ToString().ToLower() == "w")
                    {
                        if (_kennelServices.AddWashing(pet))
                        {
                            Console.WriteLine($"a washing service is added for pet name: {pet.Name}.");
                        }
                        animals[animals.IndexOf(pet)].Services[0] = pet.Services[0];
                        exit = true;
                    }
                    else if (input.KeyChar.ToString().ToLower() == "t")
                    {
                        if (_kennelServices.AddClawTrimming(pet))
                        {
                            Console.WriteLine($"a trimming service is added for pet name: {pet.Name}.");
                        }
                        animals[animals.IndexOf(pet)].Services[1] = pet.Services[1];
                        exit = true;
                    }
                    else if (input.KeyChar.ToString().ToLower() == "g")
                    {
                        if (_kennelServices.AddPetGrooming(pet))
                        {
                            Console.WriteLine($"a grooming service is added for pet name: {pet.Name}.");
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
                        Console.WriteLine("Choose one of  w: washing   t: Claw Trimming    g: Pet Grooming    e: exit");
                        input = Console.ReadKey(true);
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no pet with this name.");
            }
            
        }


        public IAnimal GetAnimal(List<IAnimal> animals)
        {
            services.Print("Enter the pets name: ");
            string str = services.GetStringValue().ToLower();
            var index = animals.IndexOf(animals.Where(a => a.Name.ToLower() == str).FirstOrDefault());

            if (index > -1)
                return animals[index];
            else
                return null;
        }



    }
}
