using VendingMachine.Application.Entities;
using VendingMachine.Application.Features.Queries.ShowAvailableProducts;

namespace VendingMachine.App;

public partial class App
{
  private async Task ShowAvailableProducts()
  {
    var query = new ShowAvailableProductsQuery();
    var result = await _commandBus.SendAsync<ShowAvailableProductsQuery, List<VendingMachineProduct>>(query);
    _consolePrinter.DisplayProducts(result.Value!);
  }
}