using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Extensions;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Infrastructure.Persistence;

public class UserWallet : IUserWallet
{
  public UserWallet()
  {
    Wallet = new Dictionary<CoinType, int>();
  }

  public Dictionary<CoinType, int> Wallet { get; }

  public void AddCoins(CoinType coinType, int quantity)
  {
    Wallet.AddCoins(coinType, quantity);
  }


  public void RemoveAllCoins()
  {
    Wallet.Clear();
  }

  public decimal TotalAmount()
  {
    return Wallet.TotalAmount();
  }

  public Dictionary<CoinType, int> GetAllCoins()
  {
    return Wallet;
  }
}