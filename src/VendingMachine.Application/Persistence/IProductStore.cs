using VendingMachine.Application.Entities;

namespace VendingMachine.Application.Persistence;

public interface IProductStore
{
  void DisplayAllProducts();
  VendingMachineProduct? GetProductWithName(string? requestProductName);
  void RemoveProductWithName(string? productName);
  void AddProduct(VendingMachineProduct product);
}