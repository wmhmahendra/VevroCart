using CART_DataTransfer.Request.Cart;
using CART_DataTransfer.Responce.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [ServiceContract]
    public interface ICartService
    {
        [OperationContract]
        CreditCardResponceDto SaveCard(CreditCardRequestDto CardRequest);

        [OperationContract]
        OrderResponceDto PlaceOrder(OrderRequestDto CartRequest);

        [OperationContract]
        OrderResponceDto UpdateOrderStatus(OrderRequestDto CartRequest);

        [OperationContract]
        OrderListResponceDto GetOrderList(OrderRequestDto OrderRequest);

        [OperationContract]
        OrderItemListResponceDto GetOrderById(OrderRequestDto OrderRequest);
    }
}
