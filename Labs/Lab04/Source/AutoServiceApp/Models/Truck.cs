namespace AutoServiceApp.Models;

public class Truck : IServiceable
{
    public string Brand { get; }
    public string Model { get; }
    public decimal LoadCapacityTons { get; }

    public Truck(string brand, string model, decimal loadCapacityTons)
    {
        Brand = string.IsNullOrWhiteSpace(brand)
            ? throw new ArgumentException("Марка не може бути порожньою.", nameof(brand))
            : brand.Trim();
        Model = string.IsNullOrWhiteSpace(model)
            ? throw new ArgumentException("Модель не може бути порожньою.", nameof(model))
            : model.Trim();
        LoadCapacityTons = loadCapacityTons > 0
            ? loadCapacityTons
            : throw new ArgumentOutOfRangeException(
                nameof(loadCapacityTons),
                "Вантажопідйомність має бути більшою за нуль.");
    }

    public decimal GetServiceCost() => 5000m + LoadCapacityTons * 1500m;
}
