using VendingMachine.Application.Enumerations;

namespace VendingMachine.Application.Persistence;

public interface IMachineWallet
{
  void AddCoins(CoinType coinType, int amount);

  void RemoveCoins(CoinType coinType, int amount);
}