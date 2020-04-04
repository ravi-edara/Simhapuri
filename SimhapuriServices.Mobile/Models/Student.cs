using System.ComponentModel.DataAnnotations;

namespace SimhapuriServices.Mobile.Models
{
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
}