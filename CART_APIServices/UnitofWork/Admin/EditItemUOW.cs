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
    public class EditItemUOW : UnitOfWork
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

        public EditItemUOW()
          : this(true)
        {
        }

        private EditItemUOW(bool isReadOnly)
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
                CartItem EditItem = this.CartItemRepository.FirstOrDefault(x => x.Id == Request.ItemId);

                EditItem.Price = Request.Price;
                EditItem.DiscountedPrice = Request.DiscountedPrice;
                EditItem.Category = Request.Category;
                EditItem.Description = Request.Description;

                CartItemRepository.Edit(EditItem);
                this.CartItemRepository.Save();

                this.Responce = new ItemResponceDto()
                {
                    Message = "Updated Successfully",

                };

                scope.Complete();
            }
        }
    }
}
