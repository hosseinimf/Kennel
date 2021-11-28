using System.Collections.Generic;

namespace KennelLibrary
{
    public interface IOwner
    {
        List<IAnimal> Animals { get; set; }
        int OwnerId { get; set; }
        string OwnerName { get; set; }
        int NumberOfAnimals { get; set; }
    }
}