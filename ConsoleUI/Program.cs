// See https://aka.ms/new-console-template for more information


using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

CarManager cars = new CarManager(new EfCarDal());

Car car1 = new Car { BrandId = 1, ColorId = 1, ModelYear = "Renault Clio 2022", Description = "Yeşil araba", Price = 1200 };
//cars.Add(car1);
Car car2 = new Car { BrandId = 1, ColorId = 2, ModelYear = "Renault Clio 2005 Model", Description = "Mavi Araba", Price = 1500 };
//cars.Add(car2);

Brand brand1 = new Brand { Name = "Renault" };
Brand brand2 = new Brand { Id=2 ,Name = "Nissan" };

BrandManager brandManager = new BrandManager(new EfBrandDal());
//brandManager.Add(brand1);
//brandManager.Add(brand2);
//brandManager.Update(brand2);

Color color1 = new Color { Name = "Yeşil" };
Color color2 = new Color { Name = "Mavi" };
Color color3 = new Color {Id=3, Name = "Siyah" }; 
ColorManager colorManager = new ColorManager(new EfColorDal());
//colorManager.Add(color1);
//colorManager.Add(color2);
//colorManager.Add(color3);
//colorManager.Delete(color3);
var result = cars.GetByBrandId(1);
foreach (var item in result.Data)
{
    Console.WriteLine(item.ModelYear);
}

var result2 = cars.GetByColorId(1);
foreach (var item2 in result2.Data)
{
    Console.WriteLine(item2.ModelYear);
}


foreach (var color in colorManager.GetAll().Data)
{
    Console.WriteLine(color.Name);
}
foreach (var brand in brandManager.GetAll().Data)
{
    Console.WriteLine(brand.Name);
}



//cars.Update(car1);
//cars.Delete(car1);
var result1 = cars.GetAll();

foreach (var c in result1.Data)
{
    Console.WriteLine(c.ModelYear);
}
Console.WriteLine("-------------------");
foreach (var car in cars.GetAll().Data)
{
    Console.WriteLine(car.ModelYear);
}

Console.WriteLine("-------------------");
foreach (var carDto in cars.GetCarDetails().Data)
{
    Console.WriteLine(carDto.BrandName+" / " + carDto.ModelYear + " / " + carDto.ColorName + " / " + carDto.Price);
}

Rental rental1 = new Rental { CarId = 1, CustomerId = 1 };
Rental rental2 = new Rental { CarId = 2, CustomerId = 2 };
RentalManager rentalManager = new RentalManager(new EfRentalDal());
var result3 =  rentalManager.Add(rental2);
if (result3.Success)
{
    foreach (var rental in rentalManager.GetAll().Data)
    {

        Console.WriteLine(rental.CarId + "/ " + rental.CustomerId + "/ " + rental.RentDate + " /  " + rental.ReturnDate);

    }
    Console.WriteLine(result3.Message);
}
else
{
    Console.WriteLine(result3.Message);
}


