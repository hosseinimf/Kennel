using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public class Owner : IOwner
    {
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public List<IAnimal> Animals { get; set; }
        public int NumberOfAnimals { get; set; }

        public Owner()
        {
            List<IAnimal> list = new();
        }

    }
}
