using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public class Animal : IAnimal
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int OwnerId { get; set; }
        public int[] Services { get; set; }
        public string OwnerName { get; set; } 
        public string ShowStatus()
        {
            if (Status == true)
                return "At kennel";
            else
                return "Picked up";
        }
    }
}


