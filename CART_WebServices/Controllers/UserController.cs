using CART_APIServices;
using CART_DataTransfer.Request.Admin;
using CART_DataTransfer.Responce.Admin;
using Microsoft.AspNetCore.Mvc;

namespace CART_WebServices.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("AddUser")]
        public IActionResult AddUsers(UserRequestDto UserRequest)
        {
            Services.IAdminService adminService = ServiceFactory.GetAminService();

            UserResponceDto Responce = adminService.AddUsers(UserRequest);

            if (Responce != null)
            {
                return Ok(Responce);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("EditUser")]
        public IActionResult EditUser(UserRequestDto UserRequest)
        {
            Services.IAdminService adminService = ServiceFactory.GetAminService();

            UserResponceDto Responce = adminService.EditUser(UserRequest);

            if (Responce != null)
            {
                return Ok(Responce);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("GetUser")]
        public IActionResult GetUserById(UserRequestDto UserRequest)
        {
            Services.IAdminService adminService = ServiceFactory.GetAminService();

            UserResponceDto Responce = adminService.GetUserById(UserRequest);

            if (Responce != null)
            {
                return Ok(Responce);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("GetUserList")]
        public IActionResult GetUserList(UserRequestDto UserRequest)
        {
            Services.IAdminService adminService = ServiceFactory.GetAminService();

            UserListResponceDto Responce = adminService.GetUserList(UserRequest);

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
