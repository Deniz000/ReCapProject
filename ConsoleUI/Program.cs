using Business.Conrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var car in carManager.GetByDailyPrice(0))
            {
                Console.WriteLine(car.DailyPrice);
            }
            Console.WriteLine("------------");
            foreach (var brand in brandManager.GetByBrand(2))
            {
                Console.WriteLine(brand.BrandName);
            }
            foreach (var color in colorManager.GetCarsByColorId(0))
            {
                Console.WriteLine(color.ColorId);
            }
        }
    }
}
