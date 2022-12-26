namespace VendingMachine.App.ConsoleApp;

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
        case MenuOptions.InsertCoins:
          await AcceptCoins();
          break;

        case MenuOptions.ReturnCoins:
          await ReturnCoins();
          break;

        case MenuOptions.BuyProduct:
          await BuyProduct();
          break;

        case MenuOptions.ShowAvailableProducts:
          await ShowAvailableProducts();
          break;

        case MenuOptions.ShowDepositedAmount:
          await ShowDepositedAmount();
          break;

        case MenuOptions.Exit:
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