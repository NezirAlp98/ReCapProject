using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
           CarManager carManager=new CarManager(new EfCarDal());
           foreach (var car in carManager.GetAll())
           {
               Console.WriteLine(car.Id);
               Console.WriteLine(car.Description);
               Console.WriteLine(car.DailyPrice);
           }
        }
    }
}
