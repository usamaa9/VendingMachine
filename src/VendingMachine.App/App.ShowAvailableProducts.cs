using MediatR;
using VendingMachine.Application.Features.GetAvailableProducts;

namespace VendingMachine.App;

public partial class App
{
  private async Task ShowAvailableProducts()
  {
    var query = new ShowAvailableProductsQuery();
    await _commandBus.SendAsync<ShowAvailableProductsQuery, Unit>(query);
  }
}