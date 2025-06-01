using Microsoft.AspNetCore.Mvc;
using _5_e_Commerce_App_Using_Model_Binding_Validation.Models;
namespace _5_e_Commerce_App_Using_Model_Binding_Validation.Controllers
{
    public class OrdersCotroller : Controller
    {
        [Route("order")]
        public IActionResult Create([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = string.Join('\n', ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage).ToList());
                return BadRequest(errorMessage);
            }
            return Json(new{OrderNumber = order.OrderNo});
        }
    }
}
