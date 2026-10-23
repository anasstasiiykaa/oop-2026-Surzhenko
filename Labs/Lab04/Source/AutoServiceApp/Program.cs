using AutoServiceApp.Models;

namespace AutoServiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var car1 = new Car("BMW", "X5", 2020);
            var car2 = new Car("Audi", "A6", 2022);
            var customer1 = new Customer("Олександр Коваленко");
            var customer2 = new Customer("Марія Бойко");

            Console.WriteLine("Власники та їхні автомобілі:");
            Console.WriteLine($"Власник: {customer1.Name}");
            Console.WriteLine($"Автомобіль: {car1.Brand} {car1.Model}, {car1.Year} рік");
            Console.WriteLine();
            Console.WriteLine($"Власник: {customer2.Name}");
            Console.WriteLine($"Автомобіль: {car2.Brand} {car2.Model}, {car2.Year} рік");

            var serviceOrder = new ServiceOrder(car1, customer1);
            serviceOrder.AddOperation(new ServiceOperation("Заміна мастила", 1200m));
            serviceOrder.AddOperation(new ServiceOperation("Діагностика", 800m));

            Console.WriteLine("\nСервісне замовлення:");
            Console.WriteLine($"Автомобіль: {serviceOrder.Car.Brand} {serviceOrder.Car.Model}");
            Console.WriteLine($"Власник: {serviceOrder.Customer.Name}");
            foreach (var operation in serviceOrder.Operations)
            {
                Console.WriteLine($"Операція: {operation.Name} — {operation.Cost:F2} грн");
            }
            Console.WriteLine($"Загальна вартість: {serviceOrder.GetTotalCost():F2} грн");

            List<IServiceable> serviceableVehicles =
            [
                car1,
                car2,
                new Motorcycle("Honda", "CB500"),
                new Truck("Volvo", "FH", 18m)
            ];

            ProcessServiceables(serviceableVehicles);

            Console.WriteLine("\nСтан ремонту:");
            car1.StartRepair();
            Console.WriteLine($"Чи в ремонті: {car1.IsUnderRepair}");
            car1.FinishRepair();
            Console.WriteLine($"Чи в ремонті після завершення: {car1.IsUnderRepair}");

            try
            {
                var invalidCar = new Car("Mercedes", "E-Class", 2100);
                Console.WriteLine($"Створено авто: {invalidCar.Brand} {invalidCar.Model}, {invalidCar.Year}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Помилка валідації: {ex.Message}");
            }
        }

        private static void ProcessServiceables(IEnumerable<IServiceable> serviceableVehicles)
        {
            Console.WriteLine("\nВартість обслуговування транспортних засобів:");
            decimal totalCost = 0m;
            foreach (IServiceable vehicle in serviceableVehicles)
            {
                decimal cost = vehicle.GetServiceCost();
                totalCost += cost;
                Console.WriteLine($"{vehicle.GetType().Name}: {cost:F2} грн");
            }

            Console.WriteLine($"Разом: {totalCost:F2} грн");
        }
    }
}