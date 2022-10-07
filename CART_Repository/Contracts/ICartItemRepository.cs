using CART_DataAcces.Contracts;
using CART_DataAcces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_Repository.Contracts
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
    }
}
