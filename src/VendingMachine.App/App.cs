using System.Text;
using VendingMachine.Application.Enumerations;
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
    Console.WriteLine("Hello World");

    Console.OutputEncoding = Encoding.UTF8;

    var isExitChoice = false;

    while (!isExitChoice)
    {
      DisplayMenu();

      var choice = GetUserInput();

      isExitChoice = await HandleChoiceAsync(choice);
    }
  }

  private static void DisplayMenu()
  {
    Console.WriteLine("--- Vending Machine ---");
    Console.WriteLine($"1. {MenuOptions.InsertCoins}");
    Console.WriteLine($"2. {MenuOptions.ReturnCoins}");
    Console.WriteLine($"3. {MenuOptions.BuyProduct}");
    Console.WriteLine($"4. {MenuOptions.ShowAvailableProducts}");
    Console.WriteLine($"5. {MenuOptions.ShowDepositedAmount}");
    Console.WriteLine($"6. {MenuOptions.Exit}");
  }

  private static string GetUserInput()
  {
    Console.WriteLine();
    Console.Write("Enter your choice: ");

    var input = Console.ReadLine();
    return input ?? "-1";
  }

  private async Task<bool> HandleChoiceAsync(string choice)
  {
    Console.WriteLine();

    switch (choice)
    {
      case "1":
        await AcceptCoins();
        break;

      case "2":
        Console.WriteLine($"You selected {MenuOptions.ReturnCoins}");
        break;

      case "3":
        Console.WriteLine($"You selected {MenuOptions.BuyProduct}");
        break;

      case "4":
        await ShowAvailableProducts();
        break;

      case "5":
        await ShowDepositedAmount();
        break;

      case "6":
        Console.WriteLine("You selected Exit");
        break;

      default:
        Console.WriteLine("Invalid choice.");
        break;
    }

    Console.WriteLine();

    return choice == "6";
  }
}