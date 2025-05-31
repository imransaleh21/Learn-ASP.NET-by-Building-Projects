using _5_e_Commerce_App_Using_Model_Binding_Validation.Models;
using System.ComponentModel.DataAnnotations;

namespace _5_e_Commerce_App_Using_Model_Binding_Validation.CustomValidations
{
    public class TotalInvoicePriceAttribute : ValidationAttribute
    {
        private string ProductsPropertyName { get; set; }
        public TotalInvoicePriceAttribute(string productsPropertyName)
        {
            ProductsPropertyName = productsPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                double invoicePrice = (double)value;
                var productsProperty = validationContext.ObjectType.GetProperty(ProductsPropertyName);
                var products = productsProperty?.GetValue(validationContext.ObjectInstance) as List<Product>;

                double totalPrice = 0.0;
                foreach (var product in products ?? Enumerable.Empty<Product>())
                {
                    if (product.Price.HasValue && product.Quantity.HasValue)
                    {
                        totalPrice += product.Price.Value * product.Quantity.Value;
                    }
                }
                if (totalPrice != invoicePrice)
                {
                    return new ValidationResult($"Total products price ({totalPrice}) does not match the provided invoice price ({invoicePrice}).");
                }
                return ValidationResult.Success;
            }

            return null;
        }

    }
}
