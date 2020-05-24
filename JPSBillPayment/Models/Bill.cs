using JPSBillPayment.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//using FluentValidation;


namespace JPSBillPayment.Models
{
    public class Bill
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Generated")]
        public DateTime createDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime dueDate { get; set; }

        
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer")]
        [Display(Name = "Premises Number")]
        [ValidForeignKey]
        public int premisesNumber { get; set; }
        
        
        [Display(Name = "Customer ID")]
        [UniqueCusNum]
        [Required]
        public string customerId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Address { get; set; }

        [Display(Name = "Amount Due")]
        [DataType(DataType.Currency)]
        [Required]
        public decimal amountDue { get; set; }
    }

}
