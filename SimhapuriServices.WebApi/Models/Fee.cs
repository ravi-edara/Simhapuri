using System;

namespace SimhapuriServices.WebApi.Models
{
    public class Fee
    {
        public string AdmissionNumber { get; set; }

        public decimal FeePaid { get; set; }

        public DateTime LastFeePaidDate { get; set; }

        public Student Student { get; set; }
    }

    public class FeesForAllStudentsByClass
    {
        public string ClassName { get; set; }

        public int NoOfStudents { get; set; }

        public decimal TotalFee { get; set; }

        public decimal TotalFeePaid { get; set; }

        public decimal TotalFeeBalance { get; set; }
    }
}