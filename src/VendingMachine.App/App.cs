using VendingMachine.App.IOHelpers;
using VendingMachine.Application.IOHelpers;
using VendingMachine.Application.Mediator;

namespace VendingMachine.App;

public partial class App
{
  private readonly ICommandBus _commandBus;

  private readonly IConsolePrinter _consolePrinter;

  private readonly IUserInput _userInput;

  public App(ICommandBus commandBus, IConsolePrinter consolePrinter, IUserInput userInput)
  {
    _commandBus = commandBus;
    _consolePrinter = consolePrinter;
    _userInput = userInput;
  }

  public async Task Run()
  {
    var isExitChoice = false;

    while (!isExitChoice)
    {
      _consolePrinter.DisplayMenu();

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
          _consolePrinter.ExitMessage();
          isExitChoice = true;
          break;

        default:
          _consolePrinter.InvalidMenuChoiceMessage();
          break;
      }
    }
  }
}