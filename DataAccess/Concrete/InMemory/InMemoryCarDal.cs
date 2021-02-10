using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id = 1, BrandId = 1, ColorId = 2, ModelYear = 2020, DailyPrice = 5000, Description = "Tesla",},
                new Car {Id = 2, BrandId = 4, ColorId = 1, ModelYear = 2021, DailyPrice = 6000, Description = "Mercedes",},
                new Car {Id = 3, BrandId = 3, ColorId = 2, ModelYear = 2015, DailyPrice = 2000, Description = "BMW",},
                new Car {Id = 4, BrandId = 2, ColorId = 3, ModelYear = 2019, DailyPrice = 4000, Description = "Audi",},
                new Car {Id = 5, BrandId = 5, ColorId = 4, ModelYear = 2020, DailyPrice = 4500, Description = "Lamborgini",}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car cartoUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            cartoUpdate.Id = car.Id;
            cartoUpdate.BrandId = car.BrandId;
            cartoUpdate.ColorId = car.ColorId;
            cartoUpdate.ModelYear = car.ModelYear;
            cartoUpdate.DailyPrice = car.DailyPrice;
            cartoUpdate.Description = car.Description;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetByCategory(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }
    }
}
