using CART_APIServices;
using CART_DataTransfer.Request.Admin;
using CART_DataTransfer.Responce.Admin;
using Microsoft.AspNetCore.Mvc;

namespace CART_WebServices.Controllers
{
    [Route("api/Item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpPost("AddItem")]
        public IActionResult AddItems(ItemRequestDto ItemRequest)
        {
            Services.IAdminService adminService = ServiceFactory.GetAminService();

            ItemResponceDto Responce = adminService.AddItems(ItemRequest);

            if (Responce != null)
            {
                return Ok(Responce);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("DeleteItem")]
        public IActionResult DeleteItem(ItemRequestDto ItemRequest)
        {
            Services.IAdminService adminService = ServiceFactory.GetAminService();

            ItemResponceDto Responce = adminService.DeleteItem(ItemRequest);

            if (Responce != null)
            {
                return Ok(Responce);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("EditItem")]
        public IActionResult EditeItem(ItemRequestDto ItemRequest)
        {
            Services.IAdminService adminService = ServiceFactory.GetAminService();

            ItemResponceDto Responce = adminService.EditeItem(ItemRequest);

            if (Responce != null)
            {
                return Ok(Responce);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("GetItem")]
        public IActionResult GetItemById(ItemRequestDto ItemRequest)
        {
            Services.IAdminService adminService = ServiceFactory.GetAminService();

            ItemResponceDto Responce = adminService.GetItemById(ItemRequest);

            if (Responce != null)
            {
                return Ok(Responce);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("GetItemsList")]
        public IActionResult GetItemList(ItemRequestDto ItemRequest)
        {
            Services.IAdminService adminService = ServiceFactory.GetAminService();

            ItemListResponceDto Responce = adminService.GetItemList(ItemRequest);

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
