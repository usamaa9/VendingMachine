using VendingMachine.Application.Entities;

namespace VendingMachine.Application.Persistence;

public interface IProductRepository
{
  void DisplayAllProducts();
  Product? GetProductWithName(string? requestProductName);
}