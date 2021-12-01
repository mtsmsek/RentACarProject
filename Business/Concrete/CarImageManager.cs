using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
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
        ICarImageDal _carImageDal;
        
        

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
            
            
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageNumber(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelperManager.Upload(formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll().Where(c=>c.CarId == carId).ToList());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.Id == id));
        }

        public IResult Update(IFormFile formFile,CarImage carImage)
        {
            
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
        private IResult CheckCarImageNumber(int carId)
        {
            var result = _carImageDal.GetAll().Where(c=>c.CarId ==carId);
            if (result.Count() > 5)
            {
                return new SuccessResult();

            }
            return new ErrorResult("Bir arabanın en fazla 5 adet resmi olabilir.");


        }
        private void HasCarImageImaage(IFormFile formFile,CarImage carImage)
        {
            if (formFile.ContentType == null)
            {
            carImage.ImagePath = "wwwroot/images/defaultImage.PNG";

            }
        }
    }
}
