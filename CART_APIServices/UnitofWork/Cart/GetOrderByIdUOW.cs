using CART_DataTransfer.Request.Cart;
using CART_DataTransfer.Responce.Admin;
using CART_DataTransfer.Responce.Cart;
using CART_Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_APIServices.UnitofWork.Cart
{
    public class GetOrderByIdUOW : UnitOfWork
    {
        public OrderRequestDto Request
        {
            get;
            set;
        }
        public OrderItemListResponceDto Responce
        {
            get;
            set;
        }

        public bool IsErrorOccurred
        {
            get;
            set;
        }

        public GetOrderByIdUOW()
          : this(true)
        {
        }

        private GetOrderByIdUOW(bool isReadOnly)
           : base(isReadOnly)
        {
        }

        private CartOrdersRepository CartOrdersRepository
        {
            get;
            set;
        }

        private CartOrderDetailsRepository CartOrderDetailsRepository
        {
            get;
            set;
        }

        protected override void PreExecute()
        {
            this.CartOrdersRepository = new CartOrdersRepository();
            this.CartOrderDetailsRepository = new CartOrderDetailsRepository();
            this.Responce = new OrderItemListResponceDto();
        }

        protected override void Execute()
        {
            List<OrderResponceDto> ParentList = new List<OrderResponceDto>();

            var Order = this.CartOrdersRepository.FirstOrDefault(x => x.Id == Request.OrderId);

            if (Order != null)
            {
                OrderResponceDto OrderData = new OrderResponceDto();

                OrderData.OrderId = Order.Id;
                OrderData.UserId = Order.UserId;
                OrderData.OrderDate = Order.OrderDate;
                OrderData.CardId = Order.CardId;
                OrderData.DeliveryAddressId = Order.DeliveryAddressId;
                OrderData.FirstName = Order.FirstName;
                OrderData.LastName = Order.LastName;
                OrderData.Addres1 = Order.Addres1;
                OrderData.Addres2 = Order.Addres2;
                OrderData.Addres3 = Order.Addres3;
                OrderData.Zip = Order.Zip;
                OrderData.City = Order.City;
                OrderData.Country = Order.Country;
                OrderData.Contact1 = Order.Contact1;
                OrderData.Contact2 = Order.Contact2;
                OrderData.Email = Order.Email;
                OrderData.TotalPrice = Order.TotalPrice;
                OrderData.OrderStatus = Order.OrderStatus;
                OrderData.PaymentStatus = Order.PaymentStatus;
                OrderData.Message = "Success";

                List<OrderDetailsResponceDto> ItemsData = new List<OrderDetailsResponceDto>();

                var ItemList = this.CartOrderDetailsRepository.FindBy(x => x.OrderId == Order.Id).OrderBy(x => x.Id);

                foreach (var Itemdt in ItemList)
                {
                    OrderDetailsResponceDto Item = new OrderDetailsResponceDto();

                    Item.ItemId = Itemdt.ItemId;
                    Item.ItemName = Itemdt.ItemName;
                    Item.ItemUnitPrice = Itemdt.ItemUnitPrice;
                    Item.Quantity = Itemdt.Quantity;
                    Item.TotalPrice = Itemdt.TotalPrice;
                    ItemsData.Add(Item);
                }
                OrderData.Item_List = ItemsData;

                ParentList.Add(OrderData);

                Responce.OrderItem_res = ParentList;
            }
            else
            {
                this.Responce = new OrderItemListResponceDto()
                {
                    Message = "Null"
                };
            }
        }
    }
}
