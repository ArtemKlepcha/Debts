using System;
using System.ComponentModel.DataAnnotations;

namespace Debts.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DepositAttribute : CompareAttribute
    {
        private static readonly string property = "DepositsMember";
        public DepositAttribute() : base(property) { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            var otherValue = validationContext.ObjectType.GetProperty(property).GetValue(validationContext.ObjectInstance, null);
            return (double)value != (double)otherValue ? new ValidationResult("Sum of deposits not equal Sum") : null;

        }
    }
}