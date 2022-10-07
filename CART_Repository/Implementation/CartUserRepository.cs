using CART_DataAcces.Data;
using CART_DataAcces.Implementation;
using CART_DataAcces.Models;
using CART_Repository.Contracts;

namespace CART_Repository.Implementation
{
    public class CartUserRepository : GenericRepository<VevroCartDBContext, CartUser>, ICartUserRepository
    {
    }
}
