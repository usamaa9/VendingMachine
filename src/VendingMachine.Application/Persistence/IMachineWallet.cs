using VendingMachine.Application.Enumerations;

namespace VendingMachine.Application.Persistence;

public interface IMachineWallet
{
  void AddCoins(CoinType coinType, int quantity);

  void RemoveCoins(CoinType coinType, int quantity);
}