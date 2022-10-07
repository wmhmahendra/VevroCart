using CART_APIServices.UnitofWork.Admin;
using CART_DataTransfer.Request.Admin;
using CART_DataTransfer.Responce.Admin;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_APIServices
{
    public class AdminService : IAdminService
    {
        public UserResponceDto AddUsers(UserRequestDto UserRequest)
        {
            AddUsersUOW AddUser = new AddUsersUOW()
            {
                Request = UserRequest
            };

            AddUser.DoWork();

            return AddUser.Responce;
        }

        public UserResponceDto EditUser(UserRequestDto UserRequest)
        {
            EditUserUOW EditUser = new EditUserUOW()
            {
                Request = UserRequest
            };

            EditUser.DoWork();

            return EditUser.Responce;
        }

        public UserResponceDto GetUserById(UserRequestDto UserRequest)
        {
            EditUserUOW GetUser = new EditUserUOW()
            {
                Request = UserRequest
            };

            GetUser.DoWork();

            return GetUser.Responce;
        }

        public UserListResponceDto GetUserList(UserRequestDto UserRequest)
        {
            GetUserListUOW GetUsers = new GetUserListUOW()
            {
                Request = UserRequest
            };

            GetUsers.DoWork();

            return GetUsers.Responce;
        }

        public ItemResponceDto AddItems(ItemRequestDto ItemRequest)
        {
            AddItemsUOW AddItem = new AddItemsUOW()
            {
                Request = ItemRequest
            };

            AddItem.DoWork();

            return AddItem.Responce;
        }

        public ItemResponceDto DeleteItem(ItemRequestDto ItemRequest)
        {
            DeleteItemUOW DelItem = new DeleteItemUOW()
            {
                Request = ItemRequest
            };

            DelItem.DoWork();

            return DelItem.Responce;
        }

        public ItemResponceDto EditeItem(ItemRequestDto ItemRequest)
        {
            EditItemUOW EditItem = new EditItemUOW()
            {
                Request = ItemRequest
            };

            EditItem.DoWork();

            return EditItem.Responce;
        }

        public ItemResponceDto GetItemById(ItemRequestDto ItemRequest)
        {
            GetItemByIdUOW GetItem = new GetItemByIdUOW()
            {
                Request = ItemRequest
            };

            GetItem.DoWork();

            return GetItem.Responce;
        }

        public ItemListResponceDto GetItemList(ItemRequestDto ItemRequest)
        {
            GetItemListUOW GetItems = new GetItemListUOW()
            {
                Request = ItemRequest
            };

            GetItems.DoWork();

            return GetItems.Responce;
        }
    }
}
