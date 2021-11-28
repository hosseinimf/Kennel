using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelLibrary
{
    public static class Seed
    {
        public static void SeedInfo(List<IOwner> OwnerList)
        {
            OwnerList.Add(new Owner { OwnerId = 54, OwnerName = "Anders" });
            OwnerList.Add(new Owner { OwnerId = 98, OwnerName = "Peter" });
            OwnerList.Add(new Owner { OwnerId = 44, OwnerName = "Johan" });
        }
    }
}
