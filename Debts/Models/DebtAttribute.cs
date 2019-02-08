using System;
using System.ComponentModel.DataAnnotations;

namespace Debts.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DebtAttribute : CompareAttribute
    {
        private static readonly string property = "DebtsMember";
        public DebtAttribute() : base(property) { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var otherValue = validationContext.ObjectType.GetProperty(property).GetValue(validationContext.ObjectInstance, null);
            return (double)value != (double)otherValue ? new ValidationResult("Sum of debts not equal Sum") : null;

        }
    }
}