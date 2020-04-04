using System;
using System.ComponentModel.DataAnnotations;

namespace SimhapuriServices.Mobile.Models
{
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