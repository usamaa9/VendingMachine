namespace VendingMachine.ConsoleApp.IOHelpers;

public class UserInput : IUserInput
{
  private readonly IConsoleReader _consoleReader;
  private readonly IConsoleWriter _consoleWriter;

  public UserInput(IConsoleWriter consoleWriter, IConsoleReader consoleReader)
  {
    _consoleWriter = consoleWriter;
    _consoleReader = consoleReader;
  }


  public CoinType GetCoinType()
  {
    CoinType coinType;
    while (true)
    {
      _consoleWriter.AskUserForCoinType();
      var coinTypeString = _consoleReader.ReadLine();

      var enumValues = Enum.GetValues(typeof(CoinType)).Cast<CoinType>();

      coinType = enumValues.FirstOrDefault(v =>
        string.Equals(v.GetDescription(), coinTypeString, StringComparison.OrdinalIgnoreCase));
      if (coinType == default)
      {
        _consoleWriter.InvalidCoinTypeMessage();
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
      _consoleWriter.AskUserForCoinQuantity();
      var coinQuantityString = _consoleReader.ReadLine();

      if (!int.TryParse(coinQuantityString, out var quantity))
      {
        _consoleWriter.InvalidCoinQuantityMessage();
        continue;
      }

      if (quantity <= 0)
      {
        _consoleWriter.InvalidCoinQuantityMessage();
        continue;
      }

      coinQuantity = quantity;
      break;
    }

    return coinQuantity;
  }

  public MenuOption GetUserMenuChoice()
  {
    while (true)
    {
      _consoleWriter.AskUserForMenuChoice();

      var input = _consoleReader.ReadLine();
      if (int.TryParse(input, out var choice) && choice > 0 && choice <= Enum.GetValues(typeof(MenuOption)).Length)
        return (MenuOption)(choice - 1);

      _consoleWriter.InvalidMenuChoiceMessage();
    }
  }

  public string? GetProductName()
  {
    _consoleWriter.AskForProductName();
    var productName = _consoleReader.ReadLine();
    return productName;
  }
}