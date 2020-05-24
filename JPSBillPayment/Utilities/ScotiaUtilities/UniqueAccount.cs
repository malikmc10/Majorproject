using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JPSBillPayment.ViewModels;
using JPSBillPayment.Data;

namespace JPSBillPayment.Utilities.ScotiaUtilities
{
    public class UniqueAccount: ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var _context = (BillContext)validationContext.GetService(typeof(BillContext));
            var entity = _context.Users.SingleOrDefault(e => e.AccountNum == value.ToString());

            

            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }


            return ValidationResult.Success;
        }

        public string GetErrorMessage(string premNum)
        {
            return $"Account Number {premNum} is already in use.";
        }
    }
}
