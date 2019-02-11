using Debts.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Debts.ViewModels.ValidationAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DebtSumCheckAttribute : CompareAttribute
    {
        private static readonly string property = "DebtsMember";
        public DebtSumCheckAttribute() : base(property) { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var otherValue = ((TaskViewModel)validationContext.ObjectInstance).DebtsMember;
            return (double)value != (double)otherValue ? new ValidationResult("Sum of debts not equal Sum") : null;

        }
    }
}