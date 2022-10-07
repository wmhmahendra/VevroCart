using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_APIServices
{
    public sealed class ServiceFactory
    {
        /// <summary>
        /// Gets the GetRegistrationService service.
        /// </summary>
        /// <returns></returns>
        //public static IRegistrationService GetRegistrationService()
        //{
        //    return new RegistrationService();
        //}



        /// <summary>
        /// Gets the GetAdminService service.
        /// </summary>
        /// <returns></returns>
        /// 

        public static Services.IAdminService GetAminService()
        {
            return new AdminService();
        }

        public static Services.ICartService GetCartService()
        {
            return new CartService();
        }
    }
}
