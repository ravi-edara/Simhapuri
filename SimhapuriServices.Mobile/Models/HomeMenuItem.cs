using System;
using System.Collections.Generic;
using System.Text;

namespace SimhapuriServices.Mobile.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Students,
        FeeDetails
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
