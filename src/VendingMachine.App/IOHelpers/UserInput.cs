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

  public MenuOptions GetUserMenuChoice()
  {
    while (true)
    {
      _consolePrinter.AskUserForMenuChoice();

      var input = Console.ReadLine();
      if (int.TryParse(input, out var choice) && choice > 0 && choice <= Enum.GetValues(typeof(MenuOptions)).Length)
        return (MenuOptions)(choice - 1);

      _consolePrinter.InvalidMenuChoiceMessage();
    }
  }
}