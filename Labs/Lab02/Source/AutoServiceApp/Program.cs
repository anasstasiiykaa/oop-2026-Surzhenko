using AutoServiceApp.Models;

namespace AutoServiceApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Лабораторна робота №2: Інкапсуляція та Валідація ===\n");

        // 1. Створення коректних об'єктів
        var car1 = new Car("BMW", "X5", 2020);
        var customer1 = new Customer("Олександр Коваленко");

        Console.WriteLine($"Власник: {customer1.Name}");
        Console.WriteLine($"Автомобіль: {car1.Brand} {car1.Model}, {car1.Year} рік");

        // 2. Демонстрація керування станом об'єкта
        Console.WriteLine("\n--- Перевірка стану ремонту ---");
        Console.WriteLine($"Початковий стан (в ремонті?): {car1.IsUnderRepair}");
        
        car1.StartRepair();
        Console.WriteLine($"Стан під час ремонту (в ремонті?): {car1.IsUnderRepair}");
        
        car1.FinishRepair();
        Console.WriteLine($"Стан після завершення (в ремонті?): {car1.IsUnderRepair}");

        // 3. Демонстрація обробки некоректних даних (валідація)
        Console.WriteLine("\n--- Перевірка валідації даних ---");
        try
        {
            Console.WriteLine("Спроба створити автомобіль з некоректним роком (2100):");
            var invalidCar = new Car("Audi", "A6", 2100);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Помилка валідації успішно перехоплена: {ex.Message}");
        }
    }
}