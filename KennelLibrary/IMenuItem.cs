using System;
using System.Collections.Generic;

namespace KennelLibrary
{
    public interface IMenuItem
    {
        Action Action { get; set; }
        int Choice { get; set; }
        string ItemName { get; set; }
    }
}