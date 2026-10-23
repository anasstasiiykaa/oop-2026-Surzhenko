namespace AutoServiceApp.Models;

public class Motorcycle : Vehicle
{
    private int _engineDisplacementCc;

    public int EngineDisplacementCc
    {
        get => _engineDisplacementCc;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Об'єм двигуна має бути більшим за нуль.");
            }
            _engineDisplacementCc = value;
        }
    }

    public Motorcycle(string brand, string model, int year, int engineDisplacementCc)
        : base(brand, model, year)
    {
        EngineDisplacementCc = engineDisplacementCc;
    }

    public override decimal CalculateServiceCost()
    {
        int age = DateTime.Now.Year - Year;
        return 800m + EngineDisplacementCc / 100m * 100m + age * 75m;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Мотоцикл: {Brand} {Model}, {Year} рік, двигун {EngineDisplacementCc} см³");
    }
}