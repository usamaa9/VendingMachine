namespace VendingMachine.Application.Persistence;

public interface IUserWallet
{
  Dictionary<CoinType, int> GetAllCoins();

  void AddCoins(CoinType coinType, int quantity);

  void RemoveAllCoins();

  decimal TotalAmount();
}