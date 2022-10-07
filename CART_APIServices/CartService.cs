using CART_APIServices.UnitofWork.Admin;
using CART_APIServices.UnitofWork.Cart;
using CART_DataTransfer.Request.Admin;
using CART_DataTransfer.Request.Cart;
using CART_DataTransfer.Responce.Admin;
using CART_DataTransfer.Responce.Cart;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_APIServices
{
    public class CartService : ICartService
    {
        public CreditCardResponceDto SaveCard(CreditCardRequestDto CardRequest)
        {
            SaveCardUOW AddCard = new SaveCardUOW()
            {
                Request = CardRequest
            };

            AddCard.DoWork();

            return AddCard.Responce;
        }

        public OrderResponceDto PlaceOrder(OrderRequestDto CartRequest)
        {
            PlaceOrderUOW SaveCart = new PlaceOrderUOW()
            {
                Request = CartRequest
            };

            SaveCart.DoWork();

            return SaveCart.Responce;
        }

        public OrderResponceDto UpdateOrderStatus(OrderRequestDto CartRequest)
        {
            UpdateOrderStatusUOW UpdateStatus = new UpdateOrderStatusUOW()
            {
                Request = CartRequest
            };

            UpdateStatus.DoWork();

            return UpdateStatus.Responce;
        }

        public OrderListResponceDto GetOrderList(OrderRequestDto OrderRequest)
        {
            GetOrderListUOW GetOrders = new GetOrderListUOW()
            {
                Request = OrderRequest
            };

            GetOrders.DoWork();

            return GetOrders.Responce;
        }

        public OrderItemListResponceDto GetOrderById(OrderRequestDto OrderRequest)
        {
            GetOrderByIdUOW GetOrders = new GetOrderByIdUOW()
            {
                Request = OrderRequest
            };

            GetOrders.DoWork();

            return GetOrders.Responce;
        }
    }
}
