using VendingMachine.Entities;

namespace VendingMachine.Persistence.Implementations;

public class ProductRepository : IProductRepository
{
    private List<Product> _products = new()
    {
        new Product {Name = "Tea", Price = 1.30m, Portions = 10},
        new Product {Name = "Espresso", Price = 1.80m, Portions = 20},
        new Product {Name = "Juice", Price = 1.80m, Portions = 20},
        new Product {Name = "Chicken Soup", Price = 1.80m, Portions = 15}
    };

    public void DisplayAllProducts()
    {
        Console.WriteLine("Product: Available Portions");
        foreach (var product in _products.Where(product => product.Portions > 0))
        {
            Console.WriteLine(product.ToNameAndPortions());
        }
    }
}
