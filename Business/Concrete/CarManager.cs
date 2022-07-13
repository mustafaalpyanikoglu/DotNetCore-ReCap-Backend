using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if(car.Description.Length>=2)
            {
                if(car.DailyPrice > 0)
                {
                    _carDal.Add(car);
                }
                else
                {
                    Console.WriteLine("Arabanın günlük fiyatı sıfırdan fazla olmalıdır!");
                }
            }
            else
            {
                Console.WriteLine("Arabanın adı iki karakterden fazla olmalıdır!");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public Car GeyById(int carId)
        {
            return _carDal.Get(c => c.CarId == carId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
