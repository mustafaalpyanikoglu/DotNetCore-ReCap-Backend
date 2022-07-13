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
            foreach (var car in carManager.GetCarDetails())
            {
                System.Console.WriteLine(car.Description+"/"+car.BrandName+"/"+car.ColorName+"/"+car.DailyPrice);
            }

            carManager.Add(new Car {ColorId=1,BrandId=2,ModelYear = "2022", DailyPrice = 45000, Description = "A3 Sportback" });
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
            System.Console.WriteLine("-----------");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                System.Console.WriteLine(car.Description + "  " + car.ColorId);
            }
            System.Console.WriteLine("-----------");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                System.Console.WriteLine(brand.BrandName);
            }

        }
    }
}
