using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SimhapuriServices.Mobile.Models
{
    public class DisplayObject
    {
        public DisplayObject(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class DisplayObjectGroup : ObservableCollection<DisplayObject>
    {
        public string Name { get; private set; }

        public DisplayObjectGroup(string name, List<DisplayObject> displayObjects) : base(displayObjects)
        {
            Name = name;
        }
    }

    public class Student
    {
        public string studentId { get; set; }
        public string admissionNumber { get; set; }
        public string name { get; set; }
        public string className { get; set; }
        public string section { get; set; }
        public string rollNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Fee Total")]
        public int feeTotal { get; set; }
    }

    public class FeeStructure
    {
        public string admissionNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public int balanceAmount => (student != null ? student.feeTotal : 0) - feePaid;

        [DisplayFormat(DataFormatString = "{0:C}")]
        public int feePaid { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime lastFeePaidDate { get; set; }

        public Student student { get; set; }
    }
}