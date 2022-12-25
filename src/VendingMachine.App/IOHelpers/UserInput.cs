using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Extensions;
using VendingMachine.Application.IOHelpers;

namespace VendingMachine.App.IOHelpers;

public class UserInput : IUserInput
{
  private readonly IConsolePrinter _consolePrinter;

  public UserInput(IConsolePrinter consolePrinter)
  {
    _consolePrinter = consolePrinter;
  }

  public CoinType GetCoinType()
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

  public int GetCoinQuantity()
  {
    throw new NotImplementedException();
  }
}