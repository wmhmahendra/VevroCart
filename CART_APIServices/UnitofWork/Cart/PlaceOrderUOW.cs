using CART_DataAcces.Models;
using CART_DataTransfer.Request.Cart;
using CART_DataTransfer.Responce.Cart;
using CART_Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CART_APIServices.UnitofWork.Cart
{
    public class PlaceOrderUOW : UnitOfWork
    {
        public OrderRequestDto Request
        {
            get;
            set;
        }
        public OrderResponceDto Responce
        {
            get;
            set;
        }

        public bool IsErrorOccurred
        {
            get;
            set;
        }

        public PlaceOrderUOW()
          : this(true)
        {
        }

        private PlaceOrderUOW(bool isReadOnly)
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
            this.Responce = new OrderResponceDto();
        }

        protected override void Execute()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    CartOrder Cart = new CartOrder();

                    Cart.UserId = Request.UserId;
                    Cart.CardId = Request.CardId;
                    Cart.DeliveryAddressId = Request.DeliveryAddressId;
                    Cart.FirstName = Request.FirstName;
                    Cart.LastName = Request.LastName;
                    Cart.OrderDate = DateTime.Now;
                    Cart.Addres1 = Request.Addres1;
                    Cart.Addres2 = Request.Addres2;
                    Cart.Addres3 = Request.Addres3;
                    Cart.Zip = Request.Zip;
                    Cart.City = Request.City;
                    Cart.Country = Request.Country;
                    Cart.Contact1 = Request.Contact1;
                    Cart.Contact2 = Request.Contact2;
                    Cart.Email = Request.Email;
                    Cart.TotalPrice = Request.TotalPrice;
                    Cart.OrderStatus = "Pending";
                    Cart.PaymentStatus = "Pending";

                    this.CartOrdersRepository.Add(Cart);
                    this.CartOrdersRepository.Save();

                    int OrderID = Cart.Id;

                    if (OrderID > 0)
                    {
                        foreach (var ItemList in Request.OrderDetailsRequest)
                        {
                            CartOrderDetail CartDetails = new CartOrderDetail();

                            CartDetails.OrderId = OrderID;
                            CartDetails.ItemId = ItemList.ItemId;
                            CartDetails.ItemName = ItemList.ItemName;
                            CartDetails.ItemUnitPrice = ItemList.ItemUnitPrice;
                            CartDetails.Quantity = ItemList.Quantity;
                            CartDetails.TotalPrice = ItemList.TotalPrice;

                            this.CartOrderDetailsRepository.Add(CartDetails);
                            this.CartOrderDetailsRepository.Save();
                        }
                    }
                    scope.Complete();

                    this.Responce = new OrderResponceDto()
                    {
                        OrderId = OrderID,
                        Message = "Successfull",
                    };
                }
                catch (Exception Ex)
                {
                    scope.Dispose();
                    this.Responce = new OrderResponceDto()
                    {
                        Message = Ex.Message
                    };
                }
            }
        }
    }
}
