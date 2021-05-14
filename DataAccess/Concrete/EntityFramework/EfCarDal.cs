using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,ReCapProjectContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result =
                    from car in context.Cars
                    join brand in context.Brands on car.BrandId equals brand.BrandId
                    join color in context.Colors on car.ColorId equals color.ColorId
                    select new CarDetailDto()
                    {
                        Id = car.Id,
                        BrandName = brand.BrandName,
                        ColorName = color.ColorName,
                        ModelYear = car.ModelYear,
                        Images = (from i in context.CarImages where i.CarId == car.Id select i.ImagePath).ToList(),
                        DailyPrice = car.DailyPrice,
                        Description = car.Description,
                    };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsById(Expression<Func<Car, bool>> filter)
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var result =
                    from car in filter == null ? context.Cars:context.Cars.Where(filter)
                    join brand in context.Brands on car.BrandId equals brand.BrandId
                    join color in context.Colors on car.ColorId equals color.ColorId
                    select new CarDetailDto()
                    {
                        Id = car.Id,
                        BrandName = brand.BrandName,
                        ColorName = color.ColorName,
                        ModelYear = car.ModelYear,
                        Images =
                            (from i in context.CarImages where i.CarId == car.Id select i.ImagePath).ToList(),
                        DailyPrice = car.DailyPrice,
                        Description = car.Description
                    };
                return result.ToList();
            }
        }
    }
}
