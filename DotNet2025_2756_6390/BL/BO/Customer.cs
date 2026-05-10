namespace BO;


public class Customer
{
    public int CustomerId { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Address { get; init; }
    public string? PhoneNumber { get; init; }
    public override string ToString()
    {
        return $"ID: {CustomerId}, Name: {Name}, Phone: {PhoneNumber}, Address: {Address}";
    }
}
