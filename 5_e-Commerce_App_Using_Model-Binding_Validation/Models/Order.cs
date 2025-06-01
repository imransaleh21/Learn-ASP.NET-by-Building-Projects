using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using _5_e_Commerce_App_Using_Model_Binding_Validation.CustomValidations;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace _5_e_Commerce_App_Using_Model_Binding_Validation.Models
{
    public class Order
    {
        [BindNever]
        [JsonIgnore]
        public int? OrderNo { get; set; }

        public Order()
        {
            // Generate a random OrderNo between 100000 and 999999  
            var random = new Random();
            OrderNo = random.Next(1, 99999);
        }

        [Display(Name = "Order Date")]
        [Required(ErrorMessage = "{0} is can't be blank.")]
        [ValidOrderDate]
        public DateTime? OrderDate { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [TotalInvoicePrice("Products")]
        public double? InvoicePrice { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public List<Product>? Products { get; set; } = new();
    }

}
