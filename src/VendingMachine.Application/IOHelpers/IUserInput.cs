namespace VendingMachine.Application.IOHelpers;

public interface IUserInput
{
  CoinType GetCoinType();
  int GetCoinQuantity();
  MenuOption GetUserMenuChoice();

  string? GetProductName();
}