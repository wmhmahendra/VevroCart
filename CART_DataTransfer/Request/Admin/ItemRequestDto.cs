using CART_DataTransfer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_DataTransfer.Request.Admin
{
    public class ItemRequestDto : Pagination
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public int ItemId { get; set; }
    }
}
