using Microsoft.AspNetCore.Mvc;
using ThanhToanPayPal.Models;

namespace ThanhToanPayPal.Controllers
{
    public class PaymentController : Controller
    {
        private readonly PaypalClient _paypalClient;

        public PaymentController(PaypalClient paypalClient) {
            _paypalClient = paypalClient;
        }

        [HttpPost("/payment/create-paypal-order")]
        public async Task<IActionResult> CreateOrder()
        {
            //số tiền có thể lấy từ Session hoặc dưới client gửi lên
            var value = "1234";
            var currency_code = "USD";
            var refId = DateTime.Now.Ticks.ToString();

            try
            {
                var response = await _paypalClient.CreateOrder(value, currency_code, refId);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }

        [HttpPost("/payment/capture-paypal-order/{orderID}")]
        public IActionResult CaptureOrder(string orderID)
        {
            _paypalClient.CaptureOrder(orderID);
            return View();
        }
    }
}
