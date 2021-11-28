using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public class Services
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public string GetStringValue()
        {
            return Console.ReadLine();
        }

        public int GetIntValue()
        {

            if (int.TryParse(Console.ReadLine(), out int num))
            {
                return num;
            }
            else
            {
                Print("Please enter number!!!");
                return -1;
            }
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
    }
}
