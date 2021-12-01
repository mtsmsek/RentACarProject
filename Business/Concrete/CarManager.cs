using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _icardal;

        public CarManager(ICarDal icardal)
        {
            _icardal = icardal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            
            _icardal.Add(car);
            return new SuccessResult(Messages.CarAddedMessage);

        }

        public IResult Delete(Car car)
        {
            _icardal.Delete(car);
            return new SuccessResult(Messages.CarDeleteMessage);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_icardal.GetAll());
        }

        public IDataResult<List<Car>> GetByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_icardal.GetAll().Where(p => p.BrandId == id).ToList());

        }

        public IDataResult<List<Car>> GetByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_icardal.GetAll().Where(p => p.ColorId == id).ToList());

        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_icardal.GetCarDetails().ToList());

        }

        public IResult Update(Car car)
        {
            _icardal.Update(car);
            return new SuccessResult(Messages.CarUpdateMessage);
        }
    }
}
