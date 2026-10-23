namespace AutoServiceApp.Models;

public class Motorcycle : IServiceable
{
    public string Brand { get; }
    public string Model { get; }

    public Motorcycle(string brand, string model)
    {
        Brand = string.IsNullOrWhiteSpace(brand) ? "Невідома марка" : brand.Trim();
        Model = string.IsNullOrWhiteSpace(model) ? "Невідома модель" : model.Trim();
    }

    public decimal GetServiceCost() => 2500m;
}
