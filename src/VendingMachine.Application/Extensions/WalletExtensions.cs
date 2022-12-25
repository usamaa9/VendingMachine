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

  /// <summary>
  /// Returns the change in least amount of coins.
  /// </summary>
  /// <param name="wallet"></param>
  /// <param name="change"></param>
  /// <returns></returns>
  public static Dictionary<CoinType, int> GetAmountInCoins(this Dictionary<CoinType, int> wallet, decimal change)
  {
    var testWallet = wallet.ToDictionary(x => x.Key, x => x.Value);

    // Create a dictionary to store the result
    var result = new Dictionary<CoinType, int>();

    // Initialize the result with 0 coins of each type
    foreach (CoinType coinType in Enum.GetValues(typeof(CoinType))) result[coinType] = 0;

    // Convert the change to cents
    var changeInCents = (int)(change * 100);

    // While there is still change to be given
    while (changeInCents > 0)
      // Check if we have any OneEuro coins in the wallet and if the change is greater than or equal to 100 cents
      if (testWallet.ContainsKey(CoinType.OneEuro) && testWallet[CoinType.OneEuro] > 0 && changeInCents >= 100)
      {
        // Subtract a OneEuro coin from the wallet and add it to the result
        testWallet[CoinType.OneEuro]--;
        result[CoinType.OneEuro]++;
        changeInCents -= 100;
      }
      // Check if we have any FiftyCent coins in the wallet and if the change is greater than or equal to 50 cents
      else if (testWallet.ContainsKey(CoinType.FiftyCent) && testWallet[CoinType.FiftyCent] > 0 && changeInCents >= 50)
      {
        // Subtract a FiftyCent coin from the wallet and add it to the result
        testWallet[CoinType.FiftyCent]--;
        result[CoinType.FiftyCent]++;
        changeInCents -= 50;
      }
      // Check if we have any TwentyCent coins in the wallet and if the change is greater than or equal to 20 cents
      else if (testWallet.ContainsKey(CoinType.TwentyCent) && testWallet[CoinType.TwentyCent] > 0 &&
               changeInCents >= 20)
      {
        // Subtract a TwentyCent coin from the wallet and add it to the result
        testWallet[CoinType.TwentyCent]--;
        result[CoinType.TwentyCent]++;
        changeInCents -= 20;
      }
      // Check if we have any TenCent coins in the wallet and if the change is greater than or equal to 10 cents
      else if (testWallet.ContainsKey(CoinType.TenCent) && testWallet[CoinType.TenCent] > 0 && changeInCents >= 10)
      {
        // Subtract a TenCent coin from the wallet and add it to the result
        testWallet[CoinType.TenCent]--;
        result[CoinType.TenCent]++;
        changeInCents -= 10;
      }
      else
      {
        throw new Exception("Do not have sufficient coins to return change");
      }

    return result;
  }
}