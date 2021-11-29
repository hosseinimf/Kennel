using System.Collections.Generic;

namespace KennelLibrary
{
    public interface IServices
    {
        bool CheckInput(string str);
        int GetIntValue();
        string GetStringValue();
        void OwnerInfo(IOwner owner);
        void Print(string message);
        int IdIncrement(List<IOwner> ownerList);
    }
}