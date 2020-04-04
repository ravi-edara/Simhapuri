using System;

namespace SimhapuriServices.WebApi.Models
{
    public class ClassDto
    {
        public int Id { get; set; }

        //public Guid ClassId { get; set; }

        public string Name { get; set; }

        public decimal FeeAmount { get; set; }
    }
}