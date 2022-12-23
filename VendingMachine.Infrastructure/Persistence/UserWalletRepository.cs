using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Infrastructure.Persistence;

public class UserWalletRepository : IUserWalletRepository
{
    public UserWalletRepository()
    {
        Wallet = new Dictionary<CoinType, int>();
    }

    private Dictionary<CoinType, int> Wallet { get; set; }

    public void AddCoins(CoinType coinType, int amount)
    {
        if (Wallet.TryGetValue(coinType, out var currentAmount))
        {
            Wallet[coinType] = currentAmount + amount;
        }
        else
        {
            Wallet.Add(coinType, amount);
        }
    }
}
