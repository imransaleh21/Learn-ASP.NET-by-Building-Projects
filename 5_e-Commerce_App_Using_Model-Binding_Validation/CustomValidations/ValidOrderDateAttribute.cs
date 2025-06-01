using System.ComponentModel.DataAnnotations;

namespace _5_e_Commerce_App_Using_Model_Binding_Validation.CustomValidations
{
    public class ValidOrderDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var today = DateTime.Today;
                var orderDate = value as DateTime?;
                if (orderDate < today)
                {
                    return new ValidationResult($"{validationContext.DisplayName} must be today or in future");
                }
                else if (orderDate > today.AddDays(30))
                {
                    return new ValidationResult($"{validationContext.DisplayName} must be within 30 days from today");
                }
                return ValidationResult.Success;

            }
            return null;
        }
    }
}
