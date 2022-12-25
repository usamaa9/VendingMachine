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

  private Dictionary<CoinType, int> Wallet { get; }

  public void AddCoins(CoinType coinType, int quantity)
  {
    Wallet.AddCoins(coinType, quantity);
  }

  public void DisplayCoins()
  {
    Wallet.DisplayCoins();
  }

  public void RemoveAllCoins()
  {
    Wallet.Clear();
  }

  public decimal TotalAmount()
  {
    return Wallet.TotalAmount();
  }

  public Dictionary<CoinType, int> GetCoins()
  {
    return Wallet;
  }
}