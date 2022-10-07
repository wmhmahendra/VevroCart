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
    internal class GetUserListUOW : UnitOfWork
    {
        public UserRequestDto Request
        {
            get;
            set;
        }
        public UserListResponceDto Responce
        {
            get;
            set;
        }

        public bool IsErrorOccurred
        {
            get;
            set;
        }

        public GetUserListUOW()
          : this(true)
        {
        }

        private GetUserListUOW(bool isReadOnly)
           : base(isReadOnly)
        {
        }

        private CartUserRepository CartUserRepository
        {
            get;
            set;
        }

        protected override void PreExecute()
        {

            this.CartUserRepository = new CartUserRepository();
            this.Responce = new UserListResponceDto();
        }

        protected override void Execute()
        {
            List<CartUser> User_List = this.CartUserRepository.GetAll().ToList();

            if (!string.IsNullOrWhiteSpace(Request.FirstName))
            {
                User_List = User_List.Where(x => x.FirstName == Request.FirstName).ToList();
            }
            if (!string.IsNullOrWhiteSpace(Request.LastName.ToString()))
            {
                User_List = User_List.Where(x => x.LastName == Request.LastName).ToList();
            }

            switch (Request.Sortby)
            {
                case 1:
                    User_List = User_List.OrderByDescending(s => s.FirstName).ToList();
                    break;
                case 2:
                    User_List = User_List.OrderByDescending(s => s.LastName).ToList();
                    break;
                default:
                    User_List = User_List.OrderByDescending(s => s.Id).ToList();
                    break;
            }

            int TotalRecordCount = User_List.Count();


            User_List = User_List.Skip((Request.PageNumber - 1) * Request.PageSize).Take(Request.PageSize).ToList();


            if (User_List.Count > 0)
            {
                this.Responce = new UserListResponceDto()
                {
                    UserList_res = User_List.Select(s => new UserResponceDto
                    {
                        UserId = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Username = s.Username,
                        Role = s.Role,
                        Email = s.Email
                    }).ToList(),
                    Result = "Ok",
                    Message = "Success",
                    RecordCount = TotalRecordCount
                };
            }
            else
            {
                this.Responce = new UserListResponceDto()
                {
                    Result = "null",
                    Message = "No Records"
                };
            }
        }
    }
}
