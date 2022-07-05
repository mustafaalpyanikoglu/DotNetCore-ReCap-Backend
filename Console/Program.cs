using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryProductDal());
            
            carManager.Add(new Car { CarId = 4, BrandId = 3, ColorId = 3, ModelYear = "2015", DailyPrice = 30000, Description = "Porsche" });
            
            var result = carManager.GetAll();
            
            carManager.Delete(result[0]);
            
            result[1].DailyPrice = 18000;
            carManager.Update(result[1]);
            
            foreach (var car in result)
            {
                System.Console.WriteLine(car.Description + " " + car.DailyPrice);
            }

            System.Console.WriteLine("----");
            System.Console.WriteLine(carManager.GetById(4).Description);

            
        }
    }
}
