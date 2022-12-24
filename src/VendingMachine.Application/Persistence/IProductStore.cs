using VendingMachine.Application.Entities;

namespace VendingMachine.Application.Persistence;

public interface IProductStore
{
  void DisplayAllProducts();
  Product? GetProductWithName(string? requestProductName);
}