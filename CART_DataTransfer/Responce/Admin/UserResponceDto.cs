﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_DataTransfer.Responce.Admin
{
    public class UserResponceDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Addres1 { get; set; }
        public string Addres2 { get; set; }
        public string Addres3 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
    }
}
