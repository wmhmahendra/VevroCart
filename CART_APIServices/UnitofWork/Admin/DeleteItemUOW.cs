using CART_DataAcces.Models;
using CART_DataTransfer.Request.Admin;
using CART_DataTransfer.Responce.Admin;
using CART_Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CART_APIServices.UnitofWork.Admin
{
    public class DeleteItemUOW : UnitOfWork
    {
        public ItemRequestDto Request
        {
            get;
            set;
        }
        public ItemResponceDto Responce
        {
            get;
            set;
        }

        public bool IsErrorOccurred
        {
            get;
            set;
        }

        public DeleteItemUOW()
          : this(true)
        {
        }

        private DeleteItemUOW(bool isReadOnly)
           : base(isReadOnly)
        {
        }

        private CartItemRepository CartItemRepository
        {
            get;
            set;
        }

        protected override void PreExecute()
        {
            this.CartItemRepository = new CartItemRepository();
            this.Responce = new ItemResponceDto();
        }

        protected override void Execute()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                CartItem DeleteItem = new CartItem();

                DeleteItem.Id = Request.ItemId;

                this.CartItemRepository.Delete(DeleteItem);
                this.CartItemRepository.Save();

                var Status = this.CartItemRepository.FirstOrDefault(x => x.Id == Request.ItemId);

                if (Status == null)
                {
                    this.Responce = new ItemResponceDto()
                    {
                        Message = "Deleted Successfully",
                    };
                }
                else
                {
                    this.Responce = new ItemResponceDto()
                    {
                        Message = "Unsuccessfull",
                    };
                }

                scope.Complete();
            }
        }
    }
}
