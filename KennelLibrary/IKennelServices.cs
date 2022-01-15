using System.Collections.Generic;

namespace KennelLibrary
{
    public interface IKennelServices
    {
        bool AddClawTrimming(IAnimal pet);
        bool AddPetGrooming(IAnimal pet);
        bool AddWashing(IAnimal pet);
        void AddService(List<IAnimal> animals);
        void GetReceipt(IAnimal pet);
    }
}