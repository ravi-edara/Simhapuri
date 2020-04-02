using System;

namespace SimhapuriServices.WebApi.Models
{
    public class FeeDto
    {
        public string AdmissionNumber { get; set; }

        public decimal FeePaid { get; set; }

        public DateTime FeePaidDate { get; set; }
    }
}
