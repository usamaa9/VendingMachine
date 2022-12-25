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

  public void AddCoins(CoinType coinType, int amount)
  {
    if (Wallet.TryGetValue(coinType, out var currentAmount))
      Wallet[coinType] = currentAmount + amount;
    else
      Wallet.Add(coinType, amount);
  }

  public void DisplayCoins()
  {
    var total = TotalAmount();

    if (total == 0)
    {
      Console.WriteLine("The wallet is empty.");
    }
    else
    {
      Console.WriteLine("Coin Type | Quantity");
      Console.WriteLine("-------------------");

      foreach (var entry in Wallet) Console.WriteLine($"{entry.Key.GetDescription(),-10} | {entry.Value,3}");

      Console.WriteLine("-------------------");
      Console.WriteLine($"Total amount: \u20AC{total}e");
    }
  }

  public void RemoveAllCoins()
  {
    Wallet.Clear();
  }

  public decimal TotalAmount()
  {
    decimal total = 0;

    foreach (var coin in Wallet)
    {
      var value = coin.Key switch
      {
        CoinType.TenCent => 0.1m,
        CoinType.TwentyCent => 0.2m,
        CoinType.FiftyCent => 0.5m,
        CoinType.OneEuro => 1,
        _ => 0
      };
      total += value * coin.Value;
    }

    return total;
  }

  public Dictionary<CoinType, int> GetCoins()
  {
    return Wallet;
  }
}