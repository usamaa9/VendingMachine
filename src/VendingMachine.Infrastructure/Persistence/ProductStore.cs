using VendingMachine.Application.Entities;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Infrastructure.Persistence;

public class ProductStore : IProductStore
{
  private List<VendingMachineProduct> Products { get; } = new();

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

  public List<VendingMachineProduct> GetInStockProducts()
  {
    return Products.Where(product => product.Portions > 0).ToList();
  }
}