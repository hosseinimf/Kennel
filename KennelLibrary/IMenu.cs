using System.Collections.Generic;

namespace KennelLibrary
{
    public interface IMenu
    {
        string Footer { get; set; }
        List<IMenuItem> MenuItems { get; set; }
        string Title { get; set; }
    }
}