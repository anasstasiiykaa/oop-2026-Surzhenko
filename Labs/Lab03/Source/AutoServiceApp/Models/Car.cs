namespace AutoServiceApp.Models;

public class Car : Vehicle
{
    private decimal _engineDisplacementLiters;

    public decimal EngineDisplacementLiters
    {
        get => _engineDisplacementLiters;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Об'єм двигуна має бути більшим за нуль.");
            }
            _engineDisplacementLiters = value;
        }
    }

    public Car(string brand, string model, int year, decimal engineDisplacementLiters = 2.0m)
        : base(brand, model, year)
    {
        EngineDisplacementLiters = engineDisplacementLiters;
    }

    public override decimal CalculateServiceCost()
    {
        int age = DateTime.Now.Year - Year;
        return 1500m + EngineDisplacementLiters * 500m + age * 100m;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Автомобіль: {Brand} {Model}, {Year} рік, двигун {EngineDisplacementLiters:0.0} л");
    }
}