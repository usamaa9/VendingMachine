using MediatR;
using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Extensions;
using VendingMachine.Application.Features.Commands.AcceptCoin;

namespace VendingMachine.App;

public partial class App
{
  private async Task AcceptCoins()
  {
    var coinType = GetCoinType();

    var coinQuantity = GetCoinQuantity();

    var command = new AcceptCoinCommand
    {
      CoinType = coinType,
      Quantity = coinQuantity
    };
    await _commandBus.SendAsync<AcceptCoinCommand, Unit>(command);
  }

  private int GetCoinQuantity()
  {
    int coinQuantity;

    while (true)
    {
      _consolePrinter.AskUserForCoinQuantity();
      var coinQuantityString = Console.ReadLine();

      if (!int.TryParse(coinQuantityString, out var quantity))
      {
        _consolePrinter.InvalidCoinQuantityMessage();
        continue;
      }

      if (quantity <= 0)
      {
        _consolePrinter.InvalidCoinQuantityMessage();
        continue;
      }

      coinQuantity = quantity;
      break;
    }

    return coinQuantity;
  }

  private CoinType GetCoinType()
  {
    CoinType coinType;
    while (true)
    {
      _consolePrinter.AskUserForCoinType();
      var coinTypeString = Console.ReadLine();

      var enumValues = Enum.GetValues(typeof(CoinType)).Cast<CoinType>();

      coinType = enumValues.FirstOrDefault(v =>
        string.Equals(v.GetDescription(), coinTypeString, StringComparison.OrdinalIgnoreCase));
      if (coinType == default)
      {
        _consolePrinter.InvalidCoinTypeMessage();
        continue;
      }

      break;
    }

    return coinType;
  }
}