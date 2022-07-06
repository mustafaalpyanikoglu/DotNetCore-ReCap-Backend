using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (Car car in carManager.GetAll())
            {
                System.Console.WriteLine(car.Description + "  " + car.ColorId);
            }

            carManager.Add(new Car {ColorId=1,BrandId=1,ModelYear = "2015", DailyPrice = 30000, Description = "Kaliteli" });
            System.Console.WriteLine("-----------");
            foreach (Car car in carManager.GetAll())
            {
                System.Console.WriteLine(car.Description + "  " + car.ColorId);
            }
            System.Console.WriteLine("-----------");

            var result = carManager.GetAll();

            carManager.Delete(result[0]);

            result[1].DailyPrice = 18000;
            carManager.Update(result[1]);

            //foreach (var car in result)
            //{
            //    System.Console.WriteLine(car.Description + " " + car.DailyPrice);
            //}

            foreach (Car car in carManager.GetAll())
            {
                System.Console.WriteLine(car.Description + "  " + car.ColorId);
            }

        }
    }
}
