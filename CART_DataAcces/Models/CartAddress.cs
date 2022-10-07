using System;
using System.Collections.Generic;

namespace CART_DataAcces.Models
{
    public partial class CartAddress
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Addres1 { get; set; }
        public string? Addres2 { get; set; }
        public string? Addres3 { get; set; }
        public string? Zip { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Contact1 { get; set; }
        public string? Contact2 { get; set; }
    }
}
