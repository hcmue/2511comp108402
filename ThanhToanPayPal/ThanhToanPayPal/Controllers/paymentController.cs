using Microsoft.AspNetCore.Mvc;

namespace ThanhToanPayPal.Controllers
{
    public class PaymentController : Controller
    {
        [HttpPost("/payment/create-paypal-order")]
        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost("/payment/capture-paypal-order")]
        public IActionResult CaptureOrder()
        {
            return View();
        }
    }
}
