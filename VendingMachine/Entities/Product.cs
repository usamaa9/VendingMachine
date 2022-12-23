namespace VendingMachine.Entities;

public class Product
{
    public string? Name { get; set; }

    public decimal Price { get; set; }

    public int Portions { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Price: {Price}, Portions: {Portions}";
    }

    public string ToNameAndPortions()
    {
        return $"{Name}: {Portions}";
    }
}
