using CART_DataTransfer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_DataTransfer.Request.Cart
{
    public class OrderRequestDto : Pagination
    {
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int? CardId { get; set; }
        public int DeliveryAddressId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Addres1 { get; set; }
        public string? Addres2 { get; set; }
        public string? Addres3 { get; set; }
        public string? Zip { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Contact1 { get; set; }
        public string? Contact2 { get; set; }
        public string? Email { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderId { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }

        public IList<OrderDetailsRequestDto>? OrderDetailsRequest { get; set; }

    }
}
