using VendingMachine.Application.Features.Queries.ShowAvailableProducts;

namespace VendingMachine.App;

public partial class App
{
  private async Task ShowAvailableProducts()
  {
    await _commandBus.SendAsync<ShowAvailableProductsQuery, Unit>(
      new ShowAvailableProductsQuery());
  }
}