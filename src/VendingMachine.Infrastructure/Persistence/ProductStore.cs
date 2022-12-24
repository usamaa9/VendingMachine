using VendingMachine.Application.Entities;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Infrastructure.Persistence;

public class ProductStore : IProductStore
{
  public ProductStore()
  {
    Products = new List<VendingMachineProduct>
    {
      new() { Name = "Tea", Price = 1.30m, Portions = 10 },
      new() { Name = "Espresso", Price = 1.80m, Portions = 20 },
      new() { Name = "Juice", Price = 1.80m, Portions = 20 },
      new() { Name = "Chicken Soup", Price = 1.80m, Portions = 15 }
    };
  }

  private List<VendingMachineProduct> Products { get; }

  public void DisplayAllProducts()
  {
    Console.WriteLine("Product Name          | Price       | Available Portions");
    Console.WriteLine("----------------------|-------------|-------------------");

    foreach (var product in Products.Where(product => product.Portions > 0))
      Console.WriteLine($"{product.Name,-21} | \u20AC{product.Price,-10} | {product.Portions,8}");

    Console.WriteLine("----------------------|-------------|-------------------");
    Console.WriteLine("End of list.");
  }

  public Product? GetProductWithName(string? name)
  {
    if (string.IsNullOrEmpty(name)) return null;

    var vendingMachineProduct =
      Products.FirstOrDefault(product => product.Name!.Equals(name, StringComparison.OrdinalIgnoreCase));

    if (vendingMachineProduct == null) return null;

    var product = new Product
    {
      Name = vendingMachineProduct.Name,
      Price = vendingMachineProduct.Price
    };
    return product;
  }
}