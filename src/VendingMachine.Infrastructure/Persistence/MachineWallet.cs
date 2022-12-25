using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Extensions;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Infrastructure.Persistence;

public class MachineWallet : IMachineWallet
{
  public MachineWallet()
  {
    Wallet = new Dictionary<CoinType, int>();
  }

  private Dictionary<CoinType, int> Wallet { get; }

  public void AddCoins(CoinType coinType, int quantity)
  {
    Wallet.AddCoins(coinType, quantity);
  }

  public void RemoveCoins(CoinType coinType, int quantity)
  {
    Wallet.RemoveCoins(coinType, quantity);
  }


  public bool CanGiveChange(decimal change, out Dictionary<CoinType, int>? coinsDictionary)
  {
    try
    {
      coinsDictionary = Wallet.GetAmountInCoins(change);
    }
    catch (Exception)
    {
      coinsDictionary = null;
      return false;
    }

    return true;
  }
}