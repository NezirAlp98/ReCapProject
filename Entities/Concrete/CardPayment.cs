using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class CardPayment:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string NameSurname { get; set; }
        public string CardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int Cvv { get; set; }
        public string CardType { get; set; }
        public int CardLimit { get; set; }



    }
}
