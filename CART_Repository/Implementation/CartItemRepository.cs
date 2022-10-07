using CART_DataAcces.Data;
using CART_DataAcces.Implementation;
using CART_DataAcces.Models;
using CART_Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_Repository.Implementation
{
    public class CartItemRepository : GenericRepository<VevroCartDBContext, CartItem>, ICartItemRepository
    {
    }
}
