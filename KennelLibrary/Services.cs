using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public class Services : IServices
    {
        public void Print(string message)
        {
            Console.WriteLine($"  {message}");
        }


        public string GetStringValue()
        {
            string str = Console.ReadLine();

            while (String.IsNullOrWhiteSpace(str))
            {
                Print("Please enter the name correctly!!!");
                str = Console.ReadLine();
            }

            return str;
        }


        public int GetIntValue()
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Print("Please enter number!!!");
            }
            return num;
        }


        public bool CheckInput(string str)
        {
            if (!String.IsNullOrWhiteSpace(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void OwnerInfo(IOwner owner)
        {
            Print(String.Format(" {0,-10}  {1,-20}  {2,-20}", $"Name", $"Num of animals", $"Id\n"));
            Print(String.Format(" {0,-10}  {1,-20}  {2,-20}", $"{owner.OwnerName}", $"{owner.NumberOfAnimals}", $"{owner.OwnerId}\n"));           
        }


        public int IdIncrement(List<IOwner> ownerList)
        {
            var lastId = ownerList[ownerList.Count - 1].OwnerId;
            return lastId + 1;
        }


    }
}
