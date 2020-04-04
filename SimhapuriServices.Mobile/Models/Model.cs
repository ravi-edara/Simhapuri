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

        public bool IsHeader { get; set; }
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
        
        [Display(Name = "Name", Order = 1)]
        public string name { get; set; }
        
        [Display(Name = "Class", Order = 2)]
        public string className { get; set; }
        
        [Display(Name = "Section", Order = 3)]
        public string section { get; set; }
        
        [Display(Name = "Roll No.", Order = 4)]
        public string rollNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Fee Total")]
        public int feeTotal { get; set; }
    }

    public class FeeStructure
    {
        public string admissionNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Balance Amount", Order = 2)]
        public int balanceAmount => (student?.feeTotal ?? 0) - feePaid;

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Fee Paid", Order = 1)]
        public int feePaid { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        [Display(Name = "Last Feed Paid", Order = 3)]
        public DateTime lastFeePaidDate { get; set; }

        public Student student { get; set; }
    }
}