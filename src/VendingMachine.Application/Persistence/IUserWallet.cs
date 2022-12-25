using VendingMachine.Application.Enumerations;

namespace VendingMachine.Application.Persistence;

public interface IUserWallet
{
  void AddCoins(CoinType coinType, int quantity);

  void DisplayCoins();
  void RemoveAllCoins();

  decimal TotalAmount();
  Dictionary<CoinType, int> GetCoins();
}