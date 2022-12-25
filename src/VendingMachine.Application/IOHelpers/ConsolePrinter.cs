using System.Text;
using VendingMachine.Application.Extensions;
using VendingMachine.Application.IOHelpers;

namespace VendingMachine.App.IOHelpers;

public class ConsolePrinter : IConsolePrinter
{
  public ConsolePrinter()
  {
    Console.OutputEncoding = Encoding.UTF8;
  }

  public void DisplayMenu()
  {
    Console.WriteLine();
    Console.WriteLine("--- Vending Machine ---");
    Console.WriteLine($"1. {MenuOptions.InsertCoins.GetDescription()}");
    Console.WriteLine($"2. {MenuOptions.ReturnCoins.GetDescription()}");
    Console.WriteLine($"3. {MenuOptions.BuyProduct.GetDescription()}");
    Console.WriteLine($"4. {MenuOptions.ShowAvailableProducts.GetDescription()}");
    Console.WriteLine($"5. {MenuOptions.ShowDepositedAmount.GetDescription()}");
    Console.WriteLine($"6. {MenuOptions.Exit.GetDescription()}");
  }

  public void AskUserForMenuChoice()
  {
    Console.WriteLine();
    Console.Write("Enter your choice: ");
  }

  public void InvalidMenuChoiceMessage()
  {
    Console.WriteLine();
    Console.WriteLine("Invalid Choice...");
  }

  public void ExitMessage()
  {
    Console.WriteLine();
    Console.WriteLine("Exiting...");
  }

  public void AskUserForCoinType()
  {
    Console.WriteLine();
    Console.Write("Enter coin type (10c, 20c, 50c, 1e): ");
  }

  public void InvalidCoinTypeMessage()
  {
    Console.WriteLine();
    Console.WriteLine("Invalid coin type.");
  }

  public void AskUserForCoinQuantity()
  {
    Console.WriteLine();
    Console.Write("Enter coin quantity: ");
  }

  public void InvalidCoinQuantityMessage()
  {
    Console.WriteLine();
    Console.WriteLine("Please enter a positive integer for the coin quantity.");
  }

  public void AskForProductName()
  {
    Console.WriteLine();
    Console.Write("Enter product name: ");
  }
}