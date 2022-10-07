using CART_APIServices;
using CART_DataTransfer.Request.Admin;
using CART_DataTransfer.Request.Cart;
using CART_DataTransfer.Responce.Admin;
using CART_DataTransfer.Responce.Cart;
using Microsoft.AspNetCore.Mvc;

namespace CART_WebServices.Controllers
{
    [Route("api/Cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        [HttpPost("SaveCard")]
        public IActionResult SaveCard(CreditCardRequestDto CardRequest)
        {
            Services.ICartService cartService = ServiceFactory.GetCartService();

            CreditCardResponceDto Responce = cartService.SaveCard(CardRequest);

            if (Responce != null)
            {
                return Ok(Responce);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("PlaceOrder")]
        public IActionResult PlaceOrder(OrderRequestDto CartRequest)
        {
            Services.ICartService cartService = ServiceFactory.GetCartService();

            OrderResponceDto Responce = cartService.PlaceOrder(CartRequest);

            if (Responce != null)
            {
                return Ok(Responce);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("UpdateOrderStatus")]
        public IActionResult UpdateOrderStatus(OrderRequestDto CartRequest)
        {
            Services.ICartService cartService = ServiceFactory.GetCartService();

            OrderResponceDto Responce = cartService.UpdateOrderStatus(CartRequest);

            if (Responce != null)
            {
                return Ok(Responce);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
