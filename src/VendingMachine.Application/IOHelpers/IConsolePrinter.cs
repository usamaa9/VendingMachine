using VendingMachine.Application.Entities;
using VendingMachine.Application.Enumerations;

namespace VendingMachine.Application.IOHelpers;

public interface IConsolePrinter
{
  void DisplayMenu();
  void AskUserForMenuChoice();
  void InvalidMenuChoiceMessage();
  void ExitMessage();
  void AskUserForCoinType();
  void AskUserForCoinQuantity();
  void InvalidCoinTypeMessage();
  void InvalidCoinQuantityMessage();
  void AskForProductName();
  void DisplayProducts(List<VendingMachineProduct> products);
  void PrintCoins(Dictionary<CoinType, int> coins);
  void PrintChange(Dictionary<CoinType, int> coins);
  void ReturnedCoinsMessage();
  void DisplayMessage(string? message);
}