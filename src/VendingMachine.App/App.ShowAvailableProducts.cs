using VendingMachine.Application.Entities;
using VendingMachine.Application.Features.Queries.ShowAvailableProducts;

namespace VendingMachine.App;

public partial class App
{
  private async Task ShowAvailableProducts()
  {
    var result =
      await _commandBus.SendAsync<ShowAvailableProductsQuery, List<VendingMachineProduct>>(
        new ShowAvailableProductsQuery());
    _consolePrinter.DisplayProducts(result.Value!);
  }
}