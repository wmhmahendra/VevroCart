using System;
using System.Collections.Generic;

namespace CART_DataAcces.Models
{
    public partial class CartItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
    }
}
