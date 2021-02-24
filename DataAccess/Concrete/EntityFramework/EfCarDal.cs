using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.TblCars
                             join b in context.TblBrands
                             on c.CarId equals b.BrandId
                             join x in context.TblColors
                             on c.CarId equals x.ColorId
                             select new CarDetailDto 
                             {
                                 CarId = c.CarId, 
                                 BrandName = b.BrandName, 
                                 DailyPrice = c.DailyPrice, 
                                 Description = c.Description,
                                 ColorName = x.ColorName
                             };
                return result.ToList();
            }
        }
    }
}
