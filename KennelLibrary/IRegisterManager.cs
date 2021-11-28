using System.Collections.Generic;

namespace KennelLibrary
{
    public interface IRegisterManager
    {
        void RegisterAnimal(List<IAnimal> animalList);
        void RegisterOwner(List<IOwner> ownerList);
        
    }
}