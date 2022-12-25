using VendingMachine.Application.Enumerations;

namespace VendingMachine.Application.Extensions;

public static class WalletExtensions
{
  /// <summary>
  /// Adds coins to a wallet.
  /// </summary>
  /// <param name="wallet"></param>
  /// <param name="coinType">Which coin to add.</param>
  /// <param name="quantity">How many to add.</param>
  public static void AddCoins(this Dictionary<CoinType, int> wallet, CoinType coinType, int quantity)
  {
    if (wallet.TryGetValue(coinType, out var currentAmount))
      wallet[coinType] = currentAmount + quantity;
    else
      wallet.Add(coinType, quantity);
  }

  /// <summary>
  /// Removes coins from a wallet.
  /// </summary>
  /// <param name="wallet"></param>
  /// <param name="coinType">Which coin to remove.</param>
  /// <param name="quantity">How many to remove.</param>
  public static void RemoveCoins(this Dictionary<CoinType, int> wallet, CoinType coinType, int quantity)
  {
    wallet.TryGetValue(coinType, out var currentAmount);
    wallet[coinType] = currentAmount - quantity;
  }

  /// <summary>
  /// Returns the total amount in a wallet.
  /// </summary>
  /// <param name="wallet"></param>
  /// <returns></returns>
  public static decimal TotalAmount(this Dictionary<CoinType, int> wallet)
  {
    decimal total = 0;

    foreach (var coin in wallet)
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

  /// <summary>
  /// Displays the coins.
  /// </summary>
  /// <param name="wallet"></param>
  public static void DisplayCoins(this Dictionary<CoinType, int> wallet)
  {
    var total = wallet.TotalAmount();

    Console.WriteLine("Coin Type | Quantity");
    Console.WriteLine("-------------------");

    foreach (var entry in wallet) Console.WriteLine($"{entry.Key.GetDescription(),-10} | {entry.Value,3}");

    Console.WriteLine("-------------------");
    Console.WriteLine($"Total amount: \u20AC{total}e");
  }
}