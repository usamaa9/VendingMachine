namespace VendingMachine.ConsoleApp.Main;

public partial class App
{
  private readonly ICommandBus _commandBus;

  private readonly IConsoleWriter _consoleWriter;

  private readonly IUserInput _userInput;

  public App(ICommandBus commandBus, IConsoleWriter consoleWriter, IUserInput userInput)
  {
    _commandBus = commandBus;
    _consoleWriter = consoleWriter;
    _userInput = userInput;
  }

  public async Task Run()
  {
    var isExitChoice = false;

    while (!isExitChoice)
    {
      _consoleWriter.DisplayMenu();

      var choice = _userInput.GetUserMenuChoice();

      switch (choice)
      {
        case MenuOption.InsertCoins:
          await AcceptCoins();
          break;

        case MenuOption.ReturnCoins:
          await ReturnCoins();
          break;

        case MenuOption.BuyProduct:
          await BuyProduct();
          break;

        case MenuOption.ShowAvailableProducts:
          await ShowAvailableProducts();
          break;

        case MenuOption.ShowDepositedAmount:
          await ShowDepositedAmount();
          break;

        case MenuOption.Exit:
          _consoleWriter.ExitMessage();
          isExitChoice = true;
          break;

        default:
          _consoleWriter.InvalidMenuChoiceMessage();
          break;
      }
    }
  }
}