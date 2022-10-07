using System;
using System.Collections.Generic;

namespace CART_DataAcces.Models
{
    public partial class CartOrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public decimal ItemUnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual CartOrder Order { get; set; } = null!;
    }
}
