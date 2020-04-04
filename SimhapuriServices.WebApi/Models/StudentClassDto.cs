using System;

namespace SimhapuriServices.WebApi.Models
{
    public class StudentClassDto
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int ClassId { get; set; }

        public int Year { get; set; }

        public bool IsActive { get; set; }

        public decimal FeeAgreed { get; set; }

        public string Note { get; set; }
    }
}