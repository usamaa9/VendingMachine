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

  private static int GetCoinQuantity()
  {
    int coinQuantity;

    while (true)
    {
      Console.Write("Enter coin quantity: ");
      var coinQuantityString = Console.ReadLine();

      if (!int.TryParse(coinQuantityString, out var quantity))
      {
        Console.WriteLine("Please enter a positive integer for the coin quantity.");
        continue;
      }

      if (quantity <= 0)
      {
        Console.WriteLine("Please enter a positive integer for the coin quantity.");
        continue;
      }

      coinQuantity = quantity;
      break;
    }

    return coinQuantity;
  }

  private static CoinType GetCoinType()
  {
    CoinType coinType;
    while (true)
    {
      Console.Write("Enter coin type (10c, 20c, 50c, 1e): ");
      var coinTypeString = Console.ReadLine();

      var enumValues = Enum.GetValues(typeof(CoinType)).Cast<CoinType>();

      coinType = enumValues.FirstOrDefault(v =>
        string.Equals(v.GetDescription(), coinTypeString, StringComparison.OrdinalIgnoreCase));
      if (coinType == default)
      {
        Console.WriteLine("Invalid coin type.");
        continue;
      }

      break;
    }

    return coinType;
  }
}