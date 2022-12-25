using VendingMachine.App.IOHelpers;
using VendingMachine.Application.Enumerations;

namespace VendingMachine.Application.IOHelpers;

public interface IUserInput
{
  CoinType GetCoinType();
  int GetCoinQuantity();
  MenuOptions GetUserMenuChoice();

  string? GetProductName();
}