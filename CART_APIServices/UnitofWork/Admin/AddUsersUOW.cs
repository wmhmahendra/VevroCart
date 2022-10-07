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
    public class AddUsersUOW : UnitOfWork
    {
        public UserRequestDto Request
        {
            get;
            set;
        }
        public UserResponceDto Responce
        {
            get;
            set;
        }

        public bool IsErrorOccurred
        {
            get;
            set;
        }

        public AddUsersUOW()
          : this(true)
        {
        }

        private AddUsersUOW(bool isReadOnly)
           : base(isReadOnly)
        {
        }

        private CartUserRepository CartUserRepository
        {
            get;
            set;
        }

        private CartAddressRepository CartAddressRepository
        {
            get;
            set;
        }

        protected override void PreExecute()
        {

            this.CartUserRepository = new CartUserRepository();
            this.CartAddressRepository = new CartAddressRepository();
            this.Responce = new UserResponceDto();
        }

        protected override void Execute()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var Name = this.CartUserRepository.FirstOrDefault(x => x.Username.Trim() == Request.Username.Trim());

                if (Name != null)
                {
                    this.Responce = new UserResponceDto()
                    {
                        Message = "User Name Already Exists",
                        UserId = 0,
                    };
                }
                else
                {
                    CartUser InsertUsers = new CartUser();

                    InsertUsers.FirstName = Request.FirstName;
                    InsertUsers.LastName = Request.LastName;
                    InsertUsers.Username = Request.Username;
                    InsertUsers.Password = Request.Password;
                    InsertUsers.Role = Request.Role;
                    InsertUsers.Email = Request.Email;

                    this.CartUserRepository.Add(InsertUsers);
                    this.CartUserRepository.Save();

                    int NewId = InsertUsers.Id;

                    if (NewId > 0)
                    {
                        CartAddress InsertAddress = new CartAddress();

                        InsertAddress.UserId = NewId;
                        InsertAddress.Addres1 = Request.Addres1;
                        InsertAddress.Addres2 = Request.Addres2;
                        InsertAddress.Addres3 = Request.Addres3;
                        InsertAddress.Zip = Request.Zip;
                        InsertAddress.City = Request.City;
                        InsertAddress.Country = Request.Country;
                        InsertAddress.Contact1 = Request.Contact1;
                        InsertAddress.Contact2 = Request.Contact2;

                        this.CartAddressRepository.Add(InsertAddress);
                        this.CartAddressRepository.Save();

                        this.Responce = new UserResponceDto()
                        {
                            Message = "Saved Successfully",
                            UserId = NewId,
                        };
                    }
                }

                scope.Complete();
            }
        }
    }
}
