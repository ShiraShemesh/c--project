using System.Diagnostics;

namespace DO;

public record Customer(int CustomerId, string Name, string Address, string PhoneNumber)
{
    public Customer() : this(0, "", "", "")
    {
    }

    public override string ToString()
    {
        return $"Customer ID: {this.CustomerId}, name: {this.Name}, Address: {this.Address}, PhoneNumber: {this.PhoneNumber}";
    }
}


