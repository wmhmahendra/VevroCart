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
    public class EditUserUOW : UnitOfWork
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

        public EditUserUOW()
          : this(true)
        {
        }

        private EditUserUOW(bool isReadOnly)
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
                CartUser EditUser = this.CartUserRepository.FirstOrDefault(x => x.Id == Request.UserId && x.Username == Request.Username);

                EditUser.FirstName = Request.FirstName;
                EditUser.LastName = Request.LastName;
                EditUser.Password = Request.Password;
                EditUser.Role = Request.Role;
                EditUser.Email = Request.Email;

                this.CartUserRepository.Edit(EditUser);
                this.CartUserRepository.Save();

                CartAddress EditAddress = this.CartAddressRepository.FirstOrDefault(x => x.UserId == Request.UserId);

                EditAddress.Addres1 = Request.Addres1;
                EditAddress.Addres2 = Request.Addres2;
                EditAddress.Addres3 = Request.Addres3;
                EditAddress.Zip = Request.Zip;
                EditAddress.City = Request.City;
                EditAddress.Country = Request.Country;
                EditAddress.Contact1 = Request.Contact1;
                EditAddress.Contact2 = Request.Contact2;

                this.CartAddressRepository.Edit(EditAddress);
                this.CartAddressRepository.Save();

                this.Responce = new UserResponceDto()
                {
                    Message = "Updated Successfully",
                };

                scope.Complete();
            }
        }
    }
}
