using VendingMachine.Application.Features.Commands.BuyProduct;
using VendingMachine.Application.Features.Events;

namespace VendingMachine.App;

public partial class App
{
  public async Task BuyProduct()
  {
    Console.Write("Enter product name: ");
    var productName = Console.ReadLine();

    var command = new BuyProductCommand
    {
      ProductName = productName
    };

    var response = await _commandBus.SendAsync<BuyProductCommand, BuyProductResponse>(command);

    if (response == null) return;
    var productResponse = (BuyProductResponse)response;
    var productBoughtEvent = new ProductBoughtEvent
    {
      ProductName = productResponse.Name,
      Price = productResponse.Price
    };
    await _commandBus.PublishAsync(productBoughtEvent);

    // TODO: do the following in the event handlers
    //return the difference between the inserted amount and the price using the smallest number of coins possible.
    //  • The amount and type of coins returned should be shown by the UI.
  }
}