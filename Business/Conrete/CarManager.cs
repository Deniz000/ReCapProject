using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Conrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByDailyPrice(decimal min)
        {
            return _carDal.GetAll(p => p.DailyPrice >= min );
        }

        void ICarService.Add(Car car)
        {
            _carDal.Add(car);
        }

        void ICarService.Delete(Car car)
        {
            _carDal.Delete(car);
        }
        void ICarService.Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
