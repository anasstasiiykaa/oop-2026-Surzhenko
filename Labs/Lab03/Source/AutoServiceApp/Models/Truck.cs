namespace AutoServiceApp.Models;

public class Truck : Vehicle
{
    private decimal _loadCapacityTons;

    public decimal LoadCapacityTons
    {
        get => _loadCapacityTons;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Вантажопідйомність має бути більшою за нуль.");
            }
            _loadCapacityTons = value;
        }
    }

    public Truck(string brand, string model, int year, decimal loadCapacityTons)
        : base(brand, model, year)
    {
        LoadCapacityTons = loadCapacityTons;
    }

    public override decimal CalculateServiceCost()
    {
        int age = DateTime.Now.Year - Year;
        return 5000m + LoadCapacityTons * 1500m + age * 250m;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Вантажівка: {Brand} {Model}, {Year} рік, вантажопідйомність {LoadCapacityTons:0.0} т");
    }
}