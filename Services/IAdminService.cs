using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using CART_DataTransfer.Request.Admin;
using CART_DataTransfer.Responce.Admin;

namespace Services
{
    [ServiceContract]
    public interface IAdminService
    {
        [OperationContract]
        UserResponceDto AddUsers(UserRequestDto UserRequest);

        [OperationContract]
        UserResponceDto EditUser(UserRequestDto UserRequest);

        [OperationContract]
        UserResponceDto GetUserById(UserRequestDto UserRequest);

        [OperationContract]
        UserListResponceDto GetUserList(UserRequestDto UserRequest);

        [OperationContract]
        ItemResponceDto AddItems(ItemRequestDto ItemRequest);

        [OperationContract]
        ItemResponceDto DeleteItem(ItemRequestDto ItemRequest);

        [OperationContract]
        ItemResponceDto EditeItem(ItemRequestDto ItemRequest);

        [OperationContract]
        ItemResponceDto GetItemById(ItemRequestDto ItemRequest);

        [OperationContract]
        ItemListResponceDto GetItemList(ItemRequestDto ItemRequest);
    }
}
