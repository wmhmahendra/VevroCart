using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_DataTransfer.Request.Cart
{
    public class CreditCardRequestDto
    {
        public string? CardNumber { get; set; }
        public string? HolderName { get; set; }
        public string? Code { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
