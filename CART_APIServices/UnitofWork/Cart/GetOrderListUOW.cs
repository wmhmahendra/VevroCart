using CART_DataAcces.Models;
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
    public class GetOrderListUOW : UnitOfWork
    {
        public OrderRequestDto Request
        {
            get;
            set;
        }
        public OrderListResponceDto Responce
        {
            get;
            set;
        }

        public bool IsErrorOccurred
        {
            get;
            set;
        }

        public GetOrderListUOW()
          : this(true)
        {
        }

        private GetOrderListUOW(bool isReadOnly)
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
            this.Responce = new OrderListResponceDto();
        }

        protected override void Execute()
        {
            List<CartOrder> Item_res = this.CartOrdersRepository.GetAll().ToList();

            if (!string.IsNullOrWhiteSpace(Request.OrderId.ToString()))
            {
                Item_res = Item_res.Where(x => x.Id == Request.OrderId).ToList();
            }
            if (!string.IsNullOrWhiteSpace(Request.FirstName.ToString()))
            {
                Item_res = Item_res.Where(x => x.FirstName == Request.FirstName).ToList();
            }

            switch (Request.Sortby)
            {
                case 1:
                    Item_res = Item_res.OrderByDescending(s => s.OrderDate).ToList();
                    break;
                case 2:
                    Item_res = Item_res.OrderByDescending(s => s.OrderStatus).ToList();
                    break;
                default:
                    Item_res = Item_res.OrderByDescending(s => s.Id).ToList();
                    break;
            }

            int TotalRecordCount = Item_res.Count();


            Item_res = Item_res.Skip((Request.PageNumber - 1) * Request.PageSize).Take(Request.PageSize).ToList();


            if (Item_res.Count > 0)
            {
                this.Responce = new OrderListResponceDto()
                {
                    OrderList_res = Item_res.Select(s => new OrderResponceDto
                    {
                        OrderId = s.Id,
                        UserId = s.UserId,
                        OrderDate = s.OrderDate,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        City = s.City,
                        Email = s.Email,
                        TotalPrice = s.TotalPrice,
                        OrderStatus = s.OrderStatus,
                        PaymentStatus = s.PaymentStatus
                    }).ToList(),
                    Result = "Ok",
                    Message = "Success",
                    RecordCount = TotalRecordCount
                };
            }
            else
            {
                this.Responce = new OrderListResponceDto()
                {
                    Result = "null",
                    Message = "No Records"
                };
            }
        }
    }
}
