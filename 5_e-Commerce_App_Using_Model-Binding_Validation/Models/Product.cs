using System.ComponentModel.DataAnnotations;

namespace _5_e_Commerce_App_Using_Model_Binding_Validation.Models
{
    public class Product
    {

        [Required(ErrorMessage = "{0} is required.")]
        public int? ProductCode { get; set; }

        //[Required(ErrorMessage = "{0} is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} must be at least {1}.")]
        public double? Price { get; set; }

        //[Required(ErrorMessage = "{0} is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} must be at least {1}.")]
        public int? Quantity { get; set; }
    }
}
