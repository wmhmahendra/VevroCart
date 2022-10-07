using CART_DataAcces.Models;
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
    public class GetItemListUOW : UnitOfWork
    {
        public ItemRequestDto Request
        {
            get;
            set;
        }
        public ItemListResponceDto Responce
        {
            get;
            set;
        }

        public bool IsErrorOccurred
        {
            get;
            set;
        }

        public GetItemListUOW()
          : this(true)
        {
        }

        private GetItemListUOW(bool isReadOnly)
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
            this.Responce = new ItemListResponceDto();
        }

        protected override void Execute()
        {
            List<CartItem> Item_res = this.CartItemRepository.GetAll().ToList();

            if (!string.IsNullOrWhiteSpace(Request.Name))
            {
                Item_res = Item_res.Where(x => x.Name == Request.Name).ToList();
            }
            if (!string.IsNullOrWhiteSpace(Request.Category.ToString()))
            {
                Item_res = Item_res.Where(x => x.Category == Request.Category).ToList();
            }

            switch (Request.Sortby)
            {
                case 1:
                    Item_res = Item_res.OrderByDescending(s => s.Price).ToList();
                    break;
                case 2:
                    Item_res = Item_res.OrderByDescending(s => s.Category).ToList();
                    break;
                default:
                    Item_res = Item_res.OrderByDescending(s => s.Name).ToList();
                    break;
            }

            int TotalRecordCount = Item_res.Count();


            Item_res = Item_res.Skip((Request.PageNumber - 1) * Request.PageSize).Take(Request.PageSize).ToList();


            if (Item_res.Count > 0)
            {
                this.Responce = new ItemListResponceDto()
                {
                    ItemList_res = Item_res.Select(s => new ItemResponceDto
                    {
                        ItemId = s.Id,
                        Name = s.Name,
                        Price = s.Price,
                        DiscountedPrice = s.DiscountedPrice,
                        Category = s.Category,
                        Description = s.Description
                    }).ToList(),
                    Result = "Ok",
                    Message = "Success",
                    RecordCount = TotalRecordCount
                };
            }
            else
            {
                this.Responce = new ItemListResponceDto()
                {
                    Result = "null",
                    Message = "No Records"
                };
            }
        }
    }
}
