namespace AutoServiceApp.Models;

public class Customer
{
    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => _name = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException("Ім'я клієнта не може бути порожнім.", nameof(value))
            : value.Trim();
    }

    public Customer(string name)
    {
        Name = name;
    }
}