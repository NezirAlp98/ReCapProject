using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetCarRentalDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result =
                    from rental in context.Rentals
                    join car in context.Cars on rental.CarId equals car.Id
                    join customer in context.Customers on rental.CustomerId equals customer.Id
                    join brand in context.Brands on car.BrandId equals brand.BrandId
                    join user in context.Users on customer.UserId equals user.Id
                    select new RentalDetailDto()
                    {
                        RentalId = rental.RentalId,
                        BrandName = brand.BrandName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate

                    };
                return result.ToList();
            }
        }
    }
}


