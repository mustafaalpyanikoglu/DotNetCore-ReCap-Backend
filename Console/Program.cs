using Business.Concrete;
using Core.Utilities.Abstract;
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
            //IDataResult<List<Entities.DTOs.CarDetailDto>> result = test1(carManager);
            //test2(carManager);
            //test3(carManager);
            //test4(carManager);

            //foreach (var car in result)
            //{
            //    System.Console.WriteLine(car.Description + " " + car.DailyPrice);
            //}

            /*test5(carManager);
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brandResult = brandManager.GetAll();
            if(brandResult.Success)
            {
                foreach (var brand in brandResult.Data)
                {
                    System.Console.WriteLine(brand.BrandName);
                }
            }*/

            //AddUser();
            //AddCustomer();
            addRental();

        }

        private static void addRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental
            {
                CarId = 5004,
                CustomerId = 3,
                RentDate = new DateTime(2021,9,10),
                ReturnDate = new DateTime(2022,9,10)
            });
            var result = rentalManager.GetAll();
            foreach (Rental rental in result.Data)
            {
                System.Console.WriteLine(rental.CarId + " " + rental.CustomerId + " " + rental.RentDate + " " + rental.ReturnDate);
            }
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer
            {
                UserId = 2,
                CompanyName = "Yanıkoğlu Rent A Car"
            });
        }

        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "Mustafa", LastName = "Yanikoglu", Email = "malpyanikoglu@gmail.com", Password = "M123456" });
            userManager.Add(new User { FirstName = "Alp", LastName = "Yanikoglu", Email = "mustafaalp58@hotmail.com", Password = "A123" });
            userManager.Add(new User { FirstName = "Engin", LastName = "Demiroğ", Email = "engin@gmail.com", Password = "engin123" });
            System.Console.WriteLine("-----------");
            var result = userManager.GetAll();
            foreach (User user in result.Data)
            {
                System.Console.WriteLine(user.FirstName + "  " + user.Email);
            }
            System.Console.WriteLine("-----------");
        }

        private static void test5(CarManager carManager)
        {
            var result = carManager.GetAll();
            if(result.Success)
            {
                foreach (Car car in result.Data)
                {
                    System.Console.WriteLine(car.Description + "  " + car.ColorId);
                }
            }
            System.Console.WriteLine("-----------");
            result = carManager.GetCarsByColorId(1);
            if(result.Success)
            {
                foreach (var car in result.Data)
                {
                    System.Console.WriteLine(car.Description + "  " + car.ColorId);
                }
            }
            System.Console.WriteLine("-----------");
        }

        private static void test4(CarManager carManager)
        {
            var result = carManager.GetAll();

            carManager.Delete(result.Data[0]);

            result.Data[1].DailyPrice = 18000;
            carManager.Update(result.Data[1]);
        }

        private static void test3(CarManager carManager)
        {
            var result = carManager.GetAll();
            foreach (Car car in result.Data)
            {
                System.Console.WriteLine(car.Description + "  " + car.ColorId);
            }
            System.Console.WriteLine("-----------");
        }

        private static void test2(CarManager carManager)
        {
            carManager.Add(new Car { ColorId = 1, BrandId = 2, ModelYear = "2022", DailyPrice = 45000, Description = "A3 Sportback" });
            System.Console.WriteLine("-----------");
        }

        private static IDataResult<List<Entities.DTOs.CarDetailDto>> test1(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    System.Console.WriteLine(car.Description + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
                }
            }
            else
            {
                System.Console.WriteLine(result.Message);
            }

            return result;
        }
    }
}
