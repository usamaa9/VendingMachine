using System.Text;
using VendingMachine.Application.ConsolePrinter;
using VendingMachine.Application.Mediator;

namespace VendingMachine.App;

public partial class App
{
  private readonly ICommandBus _commandBus;

  private readonly IConsolePrinter _consolePrinter;

  public App(ICommandBus commandBus, IConsolePrinter consolePrinter)
  {
    _commandBus = commandBus;
    _consolePrinter = consolePrinter;
  }

  public async Task Run()
  {
    Console.OutputEncoding = Encoding.UTF8;

    var isExitChoice = false;

    while (!isExitChoice)
    {
      _consolePrinter.DisplayMenu();

      var choice = GetUserMenuChoice();

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