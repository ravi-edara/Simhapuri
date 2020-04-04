using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SimhapuriServices.Mobile.Models
{
    public class DisplayObjectGroup : ObservableCollection<DisplayObject>
    {
        public string Name { get; private set; }

        public DisplayObjectGroup(string name, List<DisplayObject> displayObjects) : base(displayObjects)
        {
            Name = name;
        }
    }

    public class DisplayObject
    {
        public DisplayObject(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public bool IsHeader { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}