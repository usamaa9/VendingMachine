﻿using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Infrastructure.Persistence;

public class UserWalletRepository : IUserWalletRepository
{
  public UserWalletRepository()
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
    Console.WriteLine("Coin Type | Quantity");
    Console.WriteLine("-------------------");

    var amount = TotalAmount();

    foreach (var entry in Wallet) Console.WriteLine($"{entry.Key,-10} | {entry.Value,3}");

    Console.WriteLine("-------------------");
    Console.WriteLine($"Total amount: {amount}e");
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
}