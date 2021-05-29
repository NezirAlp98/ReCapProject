using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CardPaymentManager:ICardPaymentService
    {
        private ICardPaymentDal _cardPaymentDal;

        public CardPaymentManager(ICardPaymentDal cardPaymentDal)
        {
            _cardPaymentDal = cardPaymentDal;
        }

        public IDataResult<List<CardPayment>> GetAll()
        {
            return new SuccessDataResult<List<CardPayment>>(_cardPaymentDal.GetAll(), Messages.CardsListed);
        }

        public IDataResult<CardPayment> GetById(int id)
        {
            return new SuccessDataResult<CardPayment>(_cardPaymentDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CardPayment>> GetAllByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CardPayment>>(_cardPaymentDal.GetAll(c => c.CustomerId == customerId),
                "Müşteriler Id'ye göre listelendi");
        }

        public IResult Add(CardPayment cardPayment)
        {
            _cardPaymentDal.Add(cardPayment);
            return new SuccessResult(Messages.CardAdded);
        }

        public IResult Delete(CardPayment cardPayment)
        {
            _cardPaymentDal.Delete(cardPayment);
            return new SuccessResult(Messages.CardDeleted);
        }

        public List<CardPayment> GetPayments()
        {
            return _cardPaymentDal.GetPayments();
        }
    }
}
