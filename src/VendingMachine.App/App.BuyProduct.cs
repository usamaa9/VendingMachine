using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Features.Commands.BuyProduct;

namespace VendingMachine.App;

public partial class App
{
  public async Task BuyProduct()
  {
    var productName = _userInput.GetProductName();

    var command = new BuyProductCommand
    {
      ProductName = productName
    };

    var result = await _commandBus.SendAsync<BuyProductCommand, Dictionary<CoinType, int>?>(command);

    Console.WriteLine(result.Message);
    if (result.Value != null) _consolePrinter.PrintCoinsInWallet(result.Value);
  }
}