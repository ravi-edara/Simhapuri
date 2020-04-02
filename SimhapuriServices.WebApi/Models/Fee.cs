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
}
