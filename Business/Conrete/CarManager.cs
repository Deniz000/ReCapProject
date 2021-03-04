using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.Listed);
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length>140)
            {
                return new ErrorResult(Messages.InfoInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.InfoAdded);
        }

        public IResult Delete(Car car)
        {
            if (car.CarId.ToString() == null)
            {
                return new ErrorResult(Messages.InfoInvalid);
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.InfoDeleted);
        }
        public IResult Update(Car car)
        {
            if (car.CarId.ToString() == null)
            {
                return new ErrorResult(Messages.InfoInvalid);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.InfoUpdated);
        }
    }
}
