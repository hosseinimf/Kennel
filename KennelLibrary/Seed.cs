using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public static class Seed
    {
        public static void SeedOwner(List<IOwner> ownerList, List<IAnimal> animalList)
        {
            ownerList.Add(new Owner { OwnerId = 101, OwnerName = "Anders", NumberOfAnimals = 1 });
            ownerList.Add(new Owner { OwnerId = 102, OwnerName = "Peter", NumberOfAnimals = 1 });
            ownerList.Add(new Owner { OwnerId = 103, OwnerName = "Johan", NumberOfAnimals = 1 });

            animalList.Add(new Animal { AnimalId = 1, Name = "Piti", OwnerName = "Anders", OwnerId = 101, Status = false, Services = new int[3] { 0, 0, 0 } });
            animalList.Add(new Animal { AnimalId = 2, Name = "siti", OwnerName = "Peter", OwnerId = 102, Status = false, Services = new int[3] { 0, 0, 0 } });
            animalList.Add(new Animal { AnimalId = 3, Name = "lili", OwnerName = "Linda", OwnerId = 103, Status = false, Services = new int[3] { 0, 0, 0 } });
        }

        //added line to test the testBranch
    }
}
