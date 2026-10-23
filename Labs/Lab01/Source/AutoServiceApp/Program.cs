using AutoServiceApp.Models;

namespace AutoServiceApp;

class Program
{
    static void Main(string[] args)
    {
        var car1 = new Car { Brand = "BMW", Model = "X5", Year = 2020 };
        var car2 = new Car { Brand = "Audi", Model = "A6", Year = 2022 };

        var customer1 = new Customer { Name = "Олександр Коваленко" };
        var customer2 = new Customer { Name = "Марія Бойко" };

        Console.WriteLine("Автомобілі:");
        Console.WriteLine($"{car1.Brand} {car1.Model}, {car1.Year} рік");
        Console.WriteLine($"{car2.Brand} {car2.Model}, {car2.Year} рік");

        Console.WriteLine("Власники:");
        Console.WriteLine($"Власник: {customer1.Name}");
        Console.WriteLine($"Власник: {customer2.Name}");
    }
}