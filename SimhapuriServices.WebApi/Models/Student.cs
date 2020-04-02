using System;

namespace SimhapuriServices.WebApi.Models
{
    public class Student
    {
        public Guid StudentId { get; set; }

        public string AdmissionNumber { get; set; }

        public string Name { get; set; }

        public string ClassName { get; set; }

        public string Section { get; set; }

        public string RollNo { get; set; }

        public decimal FeeTotal { get; set; }
    }
}
