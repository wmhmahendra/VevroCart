using CART_DataTransfer.Responce.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_DataTransfer.Responce.Cart
{
    public class OrderListResponceDto
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public IList<OrderResponceDto> OrderList_res
        {
            get;
            set;
        }
        public int RecordCount { get; set; }
    }
}
