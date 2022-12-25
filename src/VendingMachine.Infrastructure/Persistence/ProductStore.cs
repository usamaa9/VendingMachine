using VendingMachine.Application.Entities;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Infrastructure.Persistence;

public class ProductStore : IProductStore
{
  private List<VendingMachineProduct> Products { get; } = new();

  public void DisplayAllProducts()
  {
    Console.WriteLine("Product Name          | Price       | Available Portions");
    Console.WriteLine("----------------------|-------------|-------------------");

    foreach (var product in Products.Where(product => product.Portions > 0))
      Console.WriteLine($"{product.Name,-21} | \u20AC{product.Price,-10} | {product.Portions,8}");

    Console.WriteLine("----------------------|-------------|-------------------");
    Console.WriteLine("End of list.");
  }

  public VendingMachineProduct? GetProductWithName(string? name)
  {
    return string.IsNullOrEmpty(name)
      ? null
      : Products.FirstOrDefault(product => product.Name!.Equals(name, StringComparison.OrdinalIgnoreCase));
  }

  public void RemoveProductWithName(string? productName)
  {
    if (string.IsNullOrEmpty(productName)) return;
    var product = Products.FirstOrDefault(p => p.Name!.Equals(productName, StringComparison.OrdinalIgnoreCase));
    if (product != null) product.Portions--;
  }

  public void AddProduct(VendingMachineProduct product)
  {
    Products.Add(product);
  }
}