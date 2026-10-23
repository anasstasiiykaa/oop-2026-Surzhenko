namespace AutoServiceApp.Models;

public class ServiceOperation
{
    public string Name { get; }
    public decimal Cost { get; }

    public ServiceOperation(string name, decimal cost)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Назва сервісної операції не може бути порожньою.", nameof(name));
        }

        if (cost < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(cost), "Вартість операції не може бути від'ємною.");
        }

        Name = name.Trim();
        Cost = cost;
    }
}
