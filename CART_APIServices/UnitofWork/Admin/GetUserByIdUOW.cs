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
    public class GetUserByIdUOW : UnitOfWork
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

        public GetUserByIdUOW()
          : this(true)
        {
        }

        private GetUserByIdUOW(bool isReadOnly)
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
            this.Responce = new UserResponceDto();
        }

        protected override void Execute()
        {
            var UserDetails = (from us in CartUserRepository.Context.CartUsers
                               join ad in CartUserRepository.Context.CartAddresses on us.Id equals ad.UserId
                               where us.Id == Request.UserId
                               select new
                               {
                                   us.Id,
                                   us.FirstName,
                                   us.LastName,
                                   us.Username,
                                   us.Password,
                                   us.Role,
                                   us.Email,
                                   ad.Addres1,
                                   ad.Addres2,
                                   ad.Addres3,
                                   ad.Zip,
                                   ad.City,
                                   ad.Country,
                                   ad.Contact1,
                                   ad.Contact2,
                               }).FirstOrDefault();

            this.Responce = new UserResponceDto()
            {
                UserId = UserDetails.Id,
                FirstName = UserDetails.FirstName,
                LastName = UserDetails.LastName,
                Username = UserDetails.Username,
                Password = UserDetails.Password,
                Role = UserDetails.Role,
                Email = UserDetails.Email,
                Addres1 = UserDetails.Addres1,
                Addres2 = UserDetails.Addres2,
                Addres3 = UserDetails.Addres3,
                Zip = UserDetails.Zip,
                City = UserDetails.City,
                Country = UserDetails.Country,
                Contact1 = UserDetails.Contact1,
                Contact2 = UserDetails.Contact2,
            };
        }
    }
}
