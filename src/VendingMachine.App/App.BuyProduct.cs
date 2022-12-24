using MediatR;
using VendingMachine.Application.Features.Commands.BuyProduct;

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

    await _commandBus.SendAsync<BuyProductCommand, Unit>(command);
  }
}