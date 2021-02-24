using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetCarsByBrandId(int id);
        List<Brand> GetByBrand(decimal min);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);


    }
}
