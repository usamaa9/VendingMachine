using System.Text;
using VendingMachine.Application.Extensions;
using VendingMachine.Application.Mediator;

namespace VendingMachine.App;

public partial class App
{
  private readonly ICommandBus _commandBus;

  public App(ICommandBus commandBus)
  {
    _commandBus = commandBus;
  }

  public async Task Run()
  {
    Console.OutputEncoding = Encoding.UTF8;

    var isExitChoice = false;

    while (!isExitChoice)
    {
      DisplayMenu();

      var choice = GetUserMenuChoice();

      isExitChoice = await HandleChoiceAsync(choice);
    }
  }

  private static void DisplayMenu()
  {
    Console.WriteLine("--- Vending Machine ---");
    Console.WriteLine($"1. {MenuOptions.InsertCoins.GetDescription()}");
    Console.WriteLine($"2. {MenuOptions.ReturnCoins.GetDescription()}");
    Console.WriteLine($"3. {MenuOptions.BuyProduct.GetDescription()}");
    Console.WriteLine($"4. {MenuOptions.ShowAvailableProducts.GetDescription()}");
    Console.WriteLine($"5. {MenuOptions.ShowDepositedAmount.GetDescription()}");
    Console.WriteLine($"6. {MenuOptions.Exit.GetDescription()}");
  }

  private static MenuOptions GetUserMenuChoice()
  {
    Console.WriteLine();
    Console.Write("Enter your choice: ");

    var input = Console.ReadLine();
    if (int.TryParse(input, out var choice) && choice > 0 && choice <= Enum.GetValues(typeof(MenuOptions)).Length)
      return (MenuOptions)(choice - 1);

    return MenuOptions.Invalid;
  }

  private async Task<bool> HandleChoiceAsync(MenuOptions choice)
  {
    Console.WriteLine();

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
        Console.WriteLine("Exiting...");
        break;

      case MenuOptions.Invalid:
        Console.WriteLine("Invalid Choice...");
        break;

      default:
        Console.WriteLine("Invalid Choice...");
        break;
    }

    return choice == MenuOptions.Exit;
  }
}