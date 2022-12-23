using VendingMachine.Application.Entities;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Infrastructure.Persistence;

public class ProductRepository : IProductRepository
{
    public ProductRepository()
    {
        Products = new List<Product>
        {
            new() {Name = "Tea", Price = 1.30m, Portions = 10},
            new() {Name = "Espresso", Price = 1.80m, Portions = 20},
            new() {Name = "Juice", Price = 1.80m, Portions = 20},
            new() {Name = "Chicken Soup", Price = 1.80m, Portions = 15}
        };
    }

    private List<Product> Products { get; set; }

    public void DisplayAllProducts()
    {
        Console.WriteLine("Product: Available Portions");
        foreach (var product in Products.Where(product => product.Portions > 0))
        {
            Console.WriteLine(product.ToNameAndPortions());
        }
    }
}
