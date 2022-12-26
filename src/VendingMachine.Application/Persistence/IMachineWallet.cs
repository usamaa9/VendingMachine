namespace VendingMachine.Application.Persistence;

public interface IMachineWallet
{
  void AddCoins(CoinType coinType, int quantity);

  void RemoveCoins(CoinType coinType, int quantity);

  /// <summary>
  /// Returns true if vending machine can return the change required, false otherwise.
  /// </summary>
  /// <param name="change"></param>
  /// <param name="coinsDictionary"></param>
  /// <returns></returns>
  bool CanGiveChange(decimal change, out Dictionary<CoinType, int>? coinsDictionary);
}