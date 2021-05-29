using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCardPaymentDal:EfEntityRepositoryBase<CardPayment,ReCapProjectContext>,ICardPaymentDal
    {
        public List<CardPayment> GetPayments()
        {
            using (var context=new ReCapProjectContext())
            {
                var result = from payment in context.CardPayments
                    join customer in context.Customers on payment.CustomerId equals customer.Id
                    select new CardPayment
                    {
                        Id = payment.Id, CustomerId = payment.CustomerId,
                        NameSurname = payment.NameSurname, CardNumber = payment.CardNumber,
                        ExpirationMonth = payment.ExpirationMonth,
                        ExpirationYear = payment.ExpirationYear, Cvv = payment.Cvv, CardLimit = payment.CardLimit,
                        CardType = payment.CardType
                    };
                return result.ToList();
            }
        }
    }
}
