using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public class KennelServices : IKennelServices
    {
        public bool AddWashing(IAnimal pet)
        {
            if (pet is not null)
            {
                pet.Services[0] = pet.Services[0] + 1;
                return true;
            }
            else
            {
                Console.WriteLine("There is no pet with this name.");
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
                Console.WriteLine("There is no pet with this name.");
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
                Console.WriteLine("There is no pet with this name.");
                return false;
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
   
            Console.WriteLine("\n -------------------- Receipt --------------------\n");
            Console.WriteLine(String.Format(" {0,-20}  {1,-20}   {2,-20}  {3,-10}", $"Pet name", $"Service", $"Charge" ,"|"));
            Console.WriteLine(String.Format(" {0,-20}  {1,-20}   {2,-20}  {3,-10}", $"{pet.Name}", $"{pet.Services[0]} Washing", $"{washingCharge} kr", "|"));
            Console.WriteLine(String.Format(" {0,-20}  {1,-20}   {2,-20}  {3,-10}", $"", $"{pet.Services[1]} Trimming", $"{trimmingCharge} kr" ,"|"));
            Console.WriteLine(String.Format(" {0,-20}  {1,-20}   {2,-20}  {3,-10}", $"", $"{pet.Services[2]} Grooming", $"{groomingCharge} kr" ,"|"));
            Console.WriteLine(String.Format(" {0,-20}  {1,-20}   {2,-20}  {3,-10}", $"", $"daily charge", $"{dailyCharge} kr" ,"|"));
            Console.WriteLine($"Total Cost is: {washingCharge + trimmingCharge + groomingCharge + dailyCharge} kr");
            Console.WriteLine("-------------------- Receipt --------------------\n");

        }
    }
}
