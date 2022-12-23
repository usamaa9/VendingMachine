using VendingMachine.Application.Enumerations;

namespace VendingMachine.Application.Persistence;

public interface IUserWalletRepository
{
    void AddCoins(CoinType coinType, int amount);
}
