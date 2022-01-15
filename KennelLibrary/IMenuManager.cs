using System;
using System.Collections.Generic;

namespace KennelLibrary
{
    public interface IMenuManager
    {
        void ShowMenu();
        void ListOwners(List<IOwner> ownerList, List<IAnimal> animalList);
        void ListAnimals(List<IAnimal> AnimalList);
        void CreateMenu(string title, string footer);
        void CreateMenuItem(int choice, string itemName);
        void ListAllAttendantAnimals(List<IAnimal> animalList);
       
    }
}