using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_DataTransfer.Responce.Admin
{
    public class ItemResponceDto
    {
        public int ItemId { get; set; }
        public string? Message { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
    }
}
