using System;

namespace SimhapuriServices.WebApi.Models
{
    public class Student
    {
        public int Id { get; set; }

        //public Guid StudentId { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string GuardianName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string AdmissionNumber { get; set; }
        public DateTime AdmittedDate { get; set; }
        public DateTime LeftDate { get; set; }
    }
}