using MediatR;
using VendingMachine.Application.Features.Queries.ShowAvailableProducts;

namespace VendingMachine.App;

public partial class App
{
  private async Task ShowAvailableProducts()
  {
    var query = new ShowAvailableProductsQuery();
    await _commandBus.SendAsync<ShowAvailableProductsQuery, Unit>(query);
  }
}