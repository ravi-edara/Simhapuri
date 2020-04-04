using System;

namespace SimhapuriServices.WebApi.Models
{
    public class FeeDto
    {
        public int Id { get; set; }

        //public Guid FeeId { get; set; }

        public int StudentClassId { get; set; }

        public decimal FeePaid { get; set; }

        // public int FeeTermId { get; set; }

        public DateTime PaidDate { get; set; }
    }
}