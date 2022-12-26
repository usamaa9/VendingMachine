using VendingMachine.Application.Features.Commands.AcceptCoin;

namespace VendingMachine.App.ConsoleApp;

public partial class App
{
  private async Task AcceptCoins()
  {
    var coinType = _userInput.GetCoinType();

    var coinQuantity = _userInput.GetCoinQuantity();

    var command = new AcceptCoinCommand
    {
      CoinType = coinType,
      Quantity = coinQuantity
    };
    await _commandBus.SendAsync<AcceptCoinCommand, Unit>(command);
  }
}