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
    public class AddItemsUOW : UnitOfWork
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

        public AddItemsUOW()
          : this(true)
        {
        }

        private AddItemsUOW(bool isReadOnly)
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
                var Name = this.CartItemRepository.FirstOrDefault(x => x.Name.Trim() == Request.Name.Trim());

                if (Name != null)
                {
                    this.Responce = new ItemResponceDto()
                    {
                        Message = "Item Name Already Exists",
                        ItemId = 0,
                    };
                }
                else
                {
                    CartItem InsertItems = new CartItem();

                    InsertItems.Name = Request.Name;
                    InsertItems.Price = Request.Price;
                    InsertItems.DiscountedPrice = Request.DiscountedPrice;
                    InsertItems.Category = Request.Category;
                    InsertItems.Description = Request.Description;

                    this.CartItemRepository.Add(InsertItems);
                    this.CartItemRepository.Save();

                    int NewId = InsertItems.Id;

                    if (NewId > 0)
                    {
                        this.Responce = new ItemResponceDto()
                        {
                            ItemId = NewId,
                            Message = "Saved Successfully",
                        };
                    }
                }

                scope.Complete();
            }
        }
    }
}
