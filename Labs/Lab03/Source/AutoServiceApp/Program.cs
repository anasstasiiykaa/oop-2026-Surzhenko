using AutoServiceApp.Models;

namespace AutoServiceApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Лабораторна робота №3: Успадкування та Поліморфізм ===\n");

        var car1 = new Car("BMW", "X5", 2020, 3.0m);
        var car2 = new Car("Audi", "A6", 2022, 2.0m);
        var customer1 = new Customer("Олександр Коваленко");

        Console.WriteLine($"Клієнт: {customer1.Name}");
        car1.DisplayInfo();

        Console.WriteLine("\n--- Перевірка ремонту ---");
        car1.StartRepair();
        car1.FinishRepair();

        // 1. Поліморфна колекція типу List<Vehicle>
        List<Vehicle> vehicles = new List<Vehicle>
        {
            car1,
            car2,
            new Truck("Volvo", "FH", 2019, 18m),
            new Motorcycle("Honda", "CB500", 2021, 500)
        };

        // 2. Виклики методів через базовий тип Vehicle
        ProcessVehicles(vehicles);
    }

    private static void ProcessVehicles(List<Vehicle> vehicles)
    {
        Console.WriteLine("\n--- Поліморфна обробка транспортних засобів ---");
        foreach (Vehicle vehicle in vehicles)
        {
            vehicle.DisplayInfo();
            Console.WriteLine($"Вартість ТО: {vehicle.CalculateServiceCost():0.00} грн\n");
        }
    }
}