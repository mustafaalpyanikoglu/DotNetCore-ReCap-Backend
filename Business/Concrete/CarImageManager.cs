using Business.Abstract;
using Business.Constants;
using Business.Constants.Messages;
using Core.Utilities.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Concrete;
using Core.Utilities.Helpers.FileHelper;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarId));
            if(result != null)
            {
                return result;
            }

            var resultOfUpload = _fileHelper.Upload(file, PathConstant.ImagesPath);
            if(!resultOfUpload.Success)
            {
                return resultOfUpload;
            }

            carImage.ImagePath = resultOfUpload.Message;
            carImage.Date = DateTime.Now;
            carImage.Id = 0;

            _carImageDal.Add(carImage);
            return new SuccessResult(CarImageMessages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = _fileHelper.Delete(PathConstant.ImagesPath + carImage.ImagePath);
            if(!result.Success)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult(CarImageMessages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), CarImageMessages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carId));
            if(!result.Success)
            {
                return new SuccessDataResult<List<CarImage>>(GetDefaultCarImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }


        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = _fileHelper.Update(file, PathConstant.ImagesPath + carImage.ImagePath, PathConstant.ImagesPath);
            if(!result.Success)
            {
                return result;
            }
            carImage.Date = DateTime.Now;
            carImage.ImagePath = result.Message;

            _carImageDal.Update(carImage);
            return new SuccessResult(CarImageMessages.CarImageUpdated);
        }
        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if(result>=5)
            {
                return new ErrorResult(CarImageMessages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> GetDefaultCarImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();

            carImages.Add(new CarImage
            {
                CarId = carId,
                Date = DateTime.Now,
                ImagePath = "wwwroot\\Images\\Default\\DefaultImage.jpg"
            });
            return new SuccessDataResult<List<CarImage>>(carImages);
        }

    }
}
