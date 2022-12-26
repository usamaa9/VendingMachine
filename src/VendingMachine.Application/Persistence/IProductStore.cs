namespace VendingMachine.Application.Persistence;

public interface IProductStore
{
  List<VendingMachineProduct> GetInStockProducts();
  VendingMachineProduct? GetProductWithName(string? requestProductName);
  void RemoveProductWithName(string? productName);
  void AddProduct(VendingMachineProduct product);
}