namespace AutoServiceApp.Models;

public class ServiceOrder
{
    private readonly List<ServiceOperation> _operations = [];

    public Car Car { get; }
    public Customer Customer { get; }
    public IReadOnlyList<ServiceOperation> Operations => _operations.AsReadOnly();

    public ServiceOrder(Car car, Customer customer)
    {
        Car = car ?? throw new ArgumentNullException(nameof(car));
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
    }

    public void AddOperation(ServiceOperation operation)
    {
        ArgumentNullException.ThrowIfNull(operation);
        _operations.Add(operation);
    }

    public decimal GetTotalCost() =>
        Car.GetServiceCost() + _operations.Sum(operation => operation.Cost);
}
