using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //GetCarTest();
            //CarAddTest();
            //ColorAddTest();
            //ColorDeleteTet();
            //ColorUpdateTest();
            //ColorGetAllTest();
            //GetByIdTest();
            //DtoTest();

            //rentalGetAll();
            //customerGetAll();
            addUser();
        }

        private static void addUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new Entities.Concrete.User
            {
                Id = 4,
                FirstName = "Ali",
                LastName = "Soy",
                Email = "ASoy@gmail.com",
                Password = "Deneme111"
            });
        }

        private static void customerGetAll()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            foreach (var customer in result.Data)
            {
                Console.WriteLine(customer.Id + "  " + customer.UserId + "  " + customer.CompanyName);
            }
        }

        private static void rentalGetAll()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            foreach (var rental in result.Data)
            {
                Console.WriteLine(rental.Id + "  " + rental.CarId + "  " + rental.RentDate + "  " + rental.ReturnDate);
            }
        }

        private static void DtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "  ->  " + car.ColorName +
                        "  ->  " + car.BrandName + "  ->  " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
  
        }

        private static void GetByIdTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.Success == true)
            {
                foreach(var color in result.Data)
                {
                    Console.WriteLine(color.Name);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
           
        }

        //private static void ColorGetAllTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());

        //    foreach (var color in colorManager.GetAll())
        //    {
        //        Console.WriteLine(color.Name);
        //    }
        //}

        private static void ColorUpdateTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Entities.Concrete.Color
            {
                Id = 3,
                Name = "Yellow",
            });
        }

        private static void ColorDeleteTet()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(new Entities.Concrete.Color
            {
                Id = 4,
                Name = "Yellow",
            });
        }

        private static void ColorAddTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Entities.Concrete.Color
            {
                Id = 4,
                Name = "Yellow",
            });
        }

        //private static void GetCarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());

        //    foreach (var car in carManager.GetCarsByBrandId(1))
        //    {
        //        Console.WriteLine(car.Description);
        //    }
        //}

        private static void CarAddTest()
        {
            CarManager carManager1 = new CarManager(new EfCarDal());
            carManager1.Add(new Entities.Concrete.Car
            {
                Id = 5,
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 0,
                Description = "Very Nice Car",
                ModelYear = 2020
            }); ;
        }
    }
}
