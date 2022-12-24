using VendingMachine.Application.Enumerations;

namespace VendingMachine.Application.Persistence;

public interface IUserWallet
{
  void AddCoins(CoinType coinType, int amount);

  void DisplayCoins();
  void RemoveAllCoins();

  decimal TotalAmount();
}