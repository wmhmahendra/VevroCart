using CART_DataAcces.Models;
using CART_DataTransfer.Request.Admin;
using CART_DataTransfer.Request.Cart;
using CART_DataTransfer.Responce.Admin;
using CART_DataTransfer.Responce.Cart;
using CART_Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CART_APIServices.UnitofWork.Cart
{
    public class SaveCardUOW : UnitOfWork
    {
        public CreditCardRequestDto Request
        {
            get;
            set;
        }
        public CreditCardResponceDto Responce
        {
            get;
            set;
        }

        public bool IsErrorOccurred
        {
            get;
            set;
        }

        public SaveCardUOW()
          : this(true)
        {
        }

        private SaveCardUOW(bool isReadOnly)
           : base(isReadOnly)
        {
        }

        private CartCreditCardRepository CartCreditCardRepository
        {
            get;
            set;
        }

        protected override void PreExecute()
        {
            this.CartCreditCardRepository = new CartCreditCardRepository();
            this.Responce = new CreditCardResponceDto();
        }

        protected override void Execute()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var Name = this.CartCreditCardRepository.FirstOrDefault(x => x.CardNumber.Trim() == Request.CardNumber.Trim());

                if (Name != null)
                {
                    this.Responce = new CreditCardResponceDto()
                    {
                        Message = "This Card Already Exists",
                        Id = 0,
                    };
                }
                else
                {
                    CartCreditCard InsertCard = new CartCreditCard();

                    InsertCard.CardNumber = Request.CardNumber;
                    InsertCard.HolderName = Request.HolderName;
                    InsertCard.Code = Request.Code;
                    InsertCard.ExpiryDate = Request.ExpiryDate;

                    this.CartCreditCardRepository.Add(InsertCard);
                    this.CartCreditCardRepository.Save();

                    int NewId = InsertCard.Id;

                    if (NewId > 0)
                    {
                        this.Responce = new CreditCardResponceDto()
                        {
                            Id = NewId,
                            Message = "Saved Successfully",
                        };
                    }
                }

                scope.Complete();
            }
        }
    }
}
