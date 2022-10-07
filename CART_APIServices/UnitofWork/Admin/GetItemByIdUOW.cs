using CART_DataTransfer.Request.Admin;
using CART_DataTransfer.Responce.Admin;
using CART_Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_APIServices.UnitofWork.Admin
{
    public class GetItemByIdUOW : UnitOfWork
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

        public GetItemByIdUOW()
          : this(true)
        {
        }

        private GetItemByIdUOW(bool isReadOnly)
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
            var Item = this.CartItemRepository.FirstOrDefault(x => x.Id == Request.ItemId);

            if (Item != null)
            {
                this.Responce = new ItemResponceDto()
                {
                    ItemId = Item.Id,
                    Name = Item.Name,
                    Price = Item.Price,
                    DiscountedPrice = Item.DiscountedPrice,
                    Category = Item.Category,
                    Description = Item.Description,
                    Message = "Success"
                };
            }
            else
            {
                this.Responce = new ItemResponceDto()
                {
                    Message = "Null"
                };
            }
        }
    }
}
