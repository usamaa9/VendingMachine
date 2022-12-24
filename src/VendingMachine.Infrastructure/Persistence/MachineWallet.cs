using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Infrastructure.Persistence;

public class MachineWallet : IMachineWallet
{
  public MachineWallet()
  {
    Wallet = new Dictionary<CoinType, int>
    {
      { CoinType.TenCent, 100 },
      { CoinType.TwentyCent, 100 },
      { CoinType.FiftyCent, 100 },
      { CoinType.OneEuro, 100 }
    };
  }

  private Dictionary<CoinType, int> Wallet { get; }

  public void AddCoins(CoinType coinType, int amount)
  {
    if (Wallet.TryGetValue(coinType, out var currentAmount))
      Wallet[coinType] = currentAmount + amount;
    else
      Wallet.Add(coinType, amount);
  }

  public void RemoveCoins(CoinType coinType, int amount)
  {
    Wallet.TryGetValue(coinType, out var currentAmount);
    Wallet[coinType] = currentAmount - amount;
  }
}