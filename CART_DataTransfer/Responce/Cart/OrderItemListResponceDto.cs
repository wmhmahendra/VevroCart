using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_DataTransfer.Responce.Cart
{
    public class OrderItemListResponceDto
    {
        public string Message { get; set; }
        public IList<OrderResponceDto> OrderItem_res
        {
            get;
            set;
        }
    }
}
