using System;
using System.Collections.Generic;

namespace CART_DataAcces.Models
{
    public partial class CartCreditCard
    {
        public CartCreditCard()
        {
            CartOrders = new HashSet<CartOrder>();
        }

        public int Id { get; set; }
        public string? CardNumber { get; set; }
        public string? HolderName { get; set; }
        public string? Code { get; set; }
        public DateTime ExpiryDate { get; set; }

        public virtual ICollection<CartOrder> CartOrders { get; set; }
    }
}
