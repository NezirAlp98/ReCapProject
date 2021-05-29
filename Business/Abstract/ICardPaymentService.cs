using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICardPaymentService
    {
        IDataResult<List<CardPayment>> GetAll();
        IDataResult<CardPayment> GetById(int id);
        IDataResult<List<CardPayment>> GetAllByCustomerId(int customerId);
        IResult Add(CardPayment cardPayment);
        IResult Delete(CardPayment cardPayment);
        List<CardPayment> GetPayments();



    }
}
