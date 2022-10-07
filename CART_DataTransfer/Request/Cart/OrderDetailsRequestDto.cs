using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_DataTransfer.Request.Cart
{
    public class OrderDetailsRequestDto
    {
        public decimal TotalPrice { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public decimal ItemUnitPrice { get; set; }
        public decimal Quantity { get; set; }
    }
}
