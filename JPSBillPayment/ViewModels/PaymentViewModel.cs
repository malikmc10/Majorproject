﻿using JPSBillPayment.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JPSBillPayment.ViewModels
{
    public class PaymentViewModel
    {
        [Display(Name = "Amount Due")]
        //[DataType(DataType.Currency)]
        [Required]
        public decimal amountPaid { get; set; }


        [Display(Name = "Customer ID")]
        [UniqueCusNum]
        [Required]
        public string customerId { get; set; }

        [Display(Name = "Card Holder Name")]
        [Required]
        public string Fname { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid integer")]
        [Display(Name = "Premises ID")]
        [ValidForeignKey]
        [Required]
        public int premisesNum { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid integer")]
        [Display(Name = "Card Number")]
        [Required]
        public int cardNumber { get; set; }
    }
}
