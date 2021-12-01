using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
       
        public InMemoryCarDal()
        {
            _cars = new List<Car>  {
            new Car { Id = 1,BrandId = 1, ColorId = 1 ,ModelYear="Renault Clio 2005 Model",Description="Mavi araba",Price=200000 },
            new Car { Id = 2,BrandId = 1, ColorId = 1 ,ModelYear="Renault Megane 2015 Model",Description="Mavi araba",Price=250000 },
            new Car { Id = 3,BrandId = 2, ColorId = 2 ,ModelYear="Nissan Micra 2010 Model",Description="Kırmızı araba",Price=400000 },
            new Car { Id = 4,BrandId = 2, ColorId = 2 ,ModelYear="Nissan Maxima 2015 Model",Description="Kırmızı araba",Price=4500000 },
            new Car { Id = 5,BrandId = 2, ColorId = 3 ,ModelYear="Primera 2020 Model",Description="Siyah araba",Price=600000 },

        };
            
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(p=>p.Id == car.Id);
            _cars.Remove(carToDelete);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
             carToUpdate.BrandId = car.BrandId ;
            carToUpdate.ColorId = car.ColorId  ;
             carToUpdate.Price = car.Price ;
             carToUpdate.Description = car.Description ;
              carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
