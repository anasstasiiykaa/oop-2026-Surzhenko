namespace AutoServiceApp.Models;

public class Car : IServiceable
{
    private string _brand = string.Empty;
    private string _model = string.Empty;
    private int _year;

    public string Brand
    {
        get => _brand;
        set => _brand = string.IsNullOrWhiteSpace(value) ? "Невідома марка" : value.Trim();
    }

    public string Model
    {
        get => _model;
        set => _model = string.IsNullOrWhiteSpace(value) ? "Невідома модель" : value.Trim();
    }

    public int Year
    {
        get => _year;
        set
        {
            int currentYear = DateTime.Now.Year;
            if (value < 1886 || value > currentYear)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    $"Рік випуску ({value}) некоректний. Очікується діапазон від 1886 до {currentYear}."
                );
            }
            _year = value;
        }
    }

    public bool IsUnderRepair { get; private set; }

    public decimal GetServiceCost() => 5000m;

    public Car(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
        IsUnderRepair = false;
    }

    public void StartRepair()
    {
        if (IsUnderRepair)
        {
            Console.WriteLine($"Автомобіль {Brand} {Model} вже знаходиться на ремонті.");
        }
        else
        {
            IsUnderRepair = true;
            Console.WriteLine($"Автомобіль {Brand} {Model} успішно прийнято на ремонт.");
        }
    }

    public void FinishRepair()
    {
        if (!IsUnderRepair)
        {
            Console.WriteLine($"Автомобіль {Brand} {Model} не перебуває на ремонті.");
        }
        else
        {
            IsUnderRepair = false;
            Console.WriteLine($"Ремонт автомобіля {Brand} {Model} завершено.");
        }
    }
}