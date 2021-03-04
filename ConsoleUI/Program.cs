using Business.Conrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandTest();
            //ColorTest();
            //CarTest();
            //UserTest();
            //CustomerTest();
            //RentalTest();
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental { CarId = 30, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = new DateTime(2021, 12, 04) });
            rentalManager.Add(new Rental { CarId = 32, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = new DateTime(2022, 10, 05) });
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.RentDate + " -- " + rental.ReturnDate);
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { CompanyName = "Dynamic" });
            foreach (var customers in customerManager.GetAll().Data)
            {
                Console.WriteLine(customers.CompanyName);
            }
            Console.WriteLine(customerManager.GetById(1).Data.CompanyName);
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "Cenk", LastName = "Kızıl", Email = "cenk00@gmail.com", Password = "cenk00" });
            //userManager.Deleted(new User { Id = 4, FirstName = "Cenk", LastName = "Kızıl", Email = "cenk00@gmail.com", Password = "cenk00" }); --silindi 

            Console.WriteLine(userManager.GetAll().Message);

            Console.WriteLine(userManager.GetById(2).Data.FirstName);
            foreach (var users in userManager.GetAll().Data)
            {
                Console.WriteLine(users.FirstName + " - " + users.Password);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 10000, Description = "Açıklama", ModelYear = "2000" });
            carManager.Add(new Car { BrandId = 2, ColorId = 2, DailyPrice = 15000, Description = "Açıklama", ModelYear = "19980" });
            carManager.Add(new Car { BrandId = 3, ColorId = 4, DailyPrice = 20000, Description = "Açıklama", ModelYear = "1996" });

            carManager.Update(new Car { CarId = 31, BrandId = 2, ColorId = 2, DailyPrice = 15000, Description = "Açıklama", ModelYear = "1992" });

            carManager.Delete(new Car { CarId = 31, BrandId = 2, ColorId = 2, DailyPrice = 15000, Description = "Açıklama", ModelYear = "1992" });

           // Delete ve Update ifadelerde Id yazmak şart, ona siliniyor eklemede is otomatik artan yaptığımız için(sql) ıd yazmamalıyız
            foreach (var cars in carManager.GetAll().Data)
            {
                Console.WriteLine(cars.ModelYear + " / " + cars.DailyPrice);
            }
            //-------------------------------------------------------------------------------------------------alt kısım çalışmadı (?)
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
                }
            }
            //------------------------------------------------------------------------------------------------------------------------
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Green" });
            colorManager.Add(new Color { ColorName = "Red" });
            colorManager.Update(new Color { ColorId = 1, ColorName = "Turuncu" });
            colorManager.Delete(new Color { ColorId = 3 });
            for (int i = 1002; i < 1008; i++) //Consol 3 kere çalıştı, değerler 3 kere eklendi, bu işlemle onları sildim
            {
                colorManager.Delete(new Color { ColorId = i });
            }
            foreach (var colors in colorManager.GetAll().Data)
            {
                Console.WriteLine(colors.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "BMW" });
            brandManager.Add(new Brand { BrandName = "Bugatti" });
            brandManager.Add(new Brand { BrandName = "Cadillac" });

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId);
            }
        }
    }
}

