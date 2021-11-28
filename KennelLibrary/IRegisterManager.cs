using System.Collections.Generic;

namespace KennelLibrary
{
    public interface IRegisterManager
    {
        void RegisterAnimal(List<IOwner> ownerList, List<IAnimal> animalList);
        void RegisterOwner(List<IOwner> ownerList, List<IAnimal> animalList);
        IOwner FindOwner(List<IAnimal> animals, List<IOwner> owners);
        void Report(List<IAnimal> animalList);


    }
}