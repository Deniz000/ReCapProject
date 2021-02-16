using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //Bellek üzerinde ürünle ilgili erişim kodlarının yazılacağı yer 
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            //default değerler, gelen
            _car = new List<Car>
            {
                new Car{Id = 1, BrandId = 11, ColorId = 254, ModelYear = 1996, DailyPrice = 40500, Description = "Bilgiler"},
                new Car{Id = 2, BrandId = 49, ColorId = 254, ModelYear = 2001, DailyPrice = 50500, Description = "Bilgiler"},
                new Car{Id = 3, BrandId = 42, ColorId = 236, ModelYear = 1984, DailyPrice = 70500, Description = "Bilgiler"},
                new Car{Id = 4, BrandId = 35, ColorId = 300, ModelYear = 1998, DailyPrice = 80500, Description = "Bilgiler"},
                new Car{Id = 5, BrandId = 22, ColorId = 298, ModelYear = 2000, DailyPrice = 100500, Description = "Bilgiler"}
        };
        }
        public void Add(Car car)
        {
          _car.Add(car); //business den gelen ürünü ekliyorum
            Console.WriteLine("Ekleme işlemi gerçekleştirildi");
        }

        public void Delete(Car car)
        {
            // => lambda
            Car carToDelete = _car.SingleOrDefault(p => p.Id == car.Id); //p = foreach item
            _car.Remove(carToDelete);
            Console.WriteLine("Silme işlemi gerçekleşti. ");

        }

        public List<Car> GetAll()
        {
            return _car; // tümünü döndürüyorum
        }

        public List<Car> GetById(int Id)
        {
            return _car.Where(p => p.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            Console.WriteLine("Güncelleme gerçekleşti. ");
        }
    }
}
