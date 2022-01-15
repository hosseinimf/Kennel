using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public class KennelServices : IKennelServices
    {
        IServices s;
        public KennelServices(IServices services)
        {
            s = services;
        }

        public bool AddWashing(IAnimal pet)
        {
            if (pet is not null)
            {
                pet.Services[0] = pet.Services[0] + 1;
                return true;
            }
            else
            {
                s.Print("There is no pet with this name.");
                return false;
            }
        }


        public bool AddClawTrimming(IAnimal pet)
        {
            if (pet is not null)
            {
                pet.Services[1] = pet.Services[1] + 1;
                return true;
            }
            else
            {
                s.Print("There is no pet with this name.");
                return false;
            }
        }


        public bool AddPetGrooming(IAnimal pet)
        {
            if (pet is not null)
            {
                pet.Services[2] = pet.Services[2] + 1;
                return true;
            }
            else
            {
                s.Print("There is no pet with this name.");
                return false;
            }
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
                        if (AddWashing(pet))
                        {
                            s.Print($"a washing service is added for pet name: {pet.Name}.");
                        }
                        animals[animals.IndexOf(pet)].Services[0] = pet.Services[0];
                        exit = true;
                    }
                    else if (input.KeyChar.ToString().ToLower() == "t")
                    {
                        if (AddClawTrimming(pet))
                        {
                            s.Print($"a trimming service is added for pet name: {pet.Name}.");
                        }
                        animals[animals.IndexOf(pet)].Services[1] = pet.Services[1];
                        exit = true;
                    }
                    else if (input.KeyChar.ToString().ToLower() == "g")
                    {
                        if (AddPetGrooming(pet))
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


        public void GetReceipt(IAnimal pet)
        {
            int washingCharge = 0;
            int trimmingCharge = 0;
            int groomingCharge = 0;
            int dailyCharge = 60;


            if (pet.Services[0] > -1)
                washingCharge = pet.Services[0] * 100;
            if (pet.Services[1] > -1)
                trimmingCharge = pet.Services[1] * 120;
            if (pet.Services[2] > -1)
                groomingCharge = pet.Services[2] * 150;
   
            s.Print("\n -------------------- Receipt --------------------\n");
            s.Print(String.Format(" {0,-20}  {1,-20}   {2,-20}  {3,-10}", $"Pet name", $"Service", $"Charge" ,"|"));
            s.Print(String.Format(" {0,-20}  {1,-20}   {2,-20}  {3,-10}", $"{pet.Name}", $"{pet.Services[0]} Washing", $"{washingCharge} kr", "|"));
            s.Print(String.Format(" {0,-20}  {1,-20}   {2,-20}  {3,-10}", $"", $"{pet.Services[1]} Trimming", $"{trimmingCharge} kr" ,"|"));
            s.Print(String.Format(" {0,-20}  {1,-20}   {2,-20}  {3,-10}", $"", $"{pet.Services[2]} Grooming", $"{groomingCharge} kr" ,"|"));
            s.Print(String.Format(" {0,-20}  {1,-20}   {2,-20}  {3,-10}", $"", $"daily charge", $"{dailyCharge} kr" ,"|"));
            s.Print($"Total Cost is: {washingCharge + trimmingCharge + groomingCharge + dailyCharge} kr");
            s.Print("-------------------- Receipt --------------------\n");

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
