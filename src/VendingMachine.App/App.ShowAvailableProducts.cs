using MediatR;
using VendingMachine.Application.Features.GetAvailableProducts;

namespace VendingMachine.App;

public partial class App
{
  private async Task ShowAvailableProducts()
  {
    var query = new GetAvailableProductsQuery();
    await _commandBus.SendAsync<GetAvailableProductsQuery, Unit>(query);
  }
}