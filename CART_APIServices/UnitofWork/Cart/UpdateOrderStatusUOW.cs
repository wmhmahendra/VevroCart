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
    public class UpdateOrderStatusUOW : UnitOfWork
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

        public UpdateOrderStatusUOW()
          : this(true)
        {
        }

        private UpdateOrderStatusUOW(bool isReadOnly)
           : base(isReadOnly)
        {
        }

        private CartOrdersRepository CartOrdersRepository
        {
            get;
            set;
        }

        protected override void PreExecute()
        {
            this.CartOrdersRepository = new CartOrdersRepository();
            this.Responce = new OrderResponceDto();
        }

        protected override void Execute()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    CartOrder Cart = this.CartOrdersRepository.FirstOrDefault(x => x.Id == Request.OrderId);

                    Cart.OrderStatus = "Completed";
                    Cart.PaymentStatus = "Paid";

                    this.CartOrdersRepository.Edit(Cart);
                    this.CartOrdersRepository.Save();

                    scope.Complete();

                    this.Responce = new OrderResponceDto()
                    {
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
