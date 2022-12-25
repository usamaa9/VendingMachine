using MediatR;
using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Extensions;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Commands.BuyProduct;

public class BuyProductCommandHandler : IRequestHandler<BuyProductCommand, Unit>
{
  private readonly IMachineWallet _machineWallet;
  private readonly IProductStore _productStore;
  private readonly IUserWallet _userWallet;


  public BuyProductCommandHandler(
    IProductStore productStore,
    IUserWallet userWallet,
    IMachineWallet machineWallet)
  {
    _productStore = productStore;
    _userWallet = userWallet;
    _machineWallet = machineWallet;
  }

  public Task<Unit> Handle(BuyProductCommand request, CancellationToken cancellationToken)
  {
    var product = _productStore.GetProductWithName(request.ProductName);

    if (product == null)
    {
      Console.WriteLine($"Product with name {request.ProductName} does not exist.");

      return Task.FromResult(Unit.Value);
    }

    var depositedAmount = _userWallet.TotalAmount();

    if (product.Price > depositedAmount)
    {
      Console.WriteLine("Insufficient amount to buy the product.");
      return Task.FromResult(Unit.Value);
    }

    Console.WriteLine("Thank you.");

    // add all the user wallet coins to the machine wallet and clear the user wallet

    var userCoins = _userWallet.GetCoins();

    foreach (var coin in userCoins) _machineWallet.AddCoins(coin.Key, coin.Value);

    _userWallet.RemoveAllCoins();

    // calculate the change which should be returned

    var change = depositedAmount - product.Price;

    // remove those coins from the machine wallet

    var changeCoins = GetAmountInCoins(change);

    foreach (var coin in changeCoins) _machineWallet.RemoveCoins(coin.Key, coin.Value);

    // output the amount and type of coins to the console.
    Console.WriteLine("Your Change");

    Console.WriteLine("Coin Type | Quantity");
    Console.WriteLine("-------------------");

    foreach (var entry in changeCoins) Console.WriteLine($"{entry.Key.GetDescription(),-10} | {entry.Value,3}");

    Console.WriteLine("-------------------");
    Console.WriteLine($"Total amount: \u20AC{change}e");


    return Task.FromResult(Unit.Value);
  }

  private static Dictionary<CoinType, int> GetAmountInCoins(decimal change)
  {
    // Initialize the coin count to zero
    var coinCount = new Dictionary<CoinType, int>
    {
      { CoinType.OneEuro, 0 },
      { CoinType.FiftyCent, 0 },
      { CoinType.TwentyCent, 0 },
      { CoinType.TenCent, 0 }
    };

    // Convert the change amount to an integer (in cents)
    var amount = (int)(change * 100);

    // Calculate the number of 1 euro coins
    coinCount[CoinType.OneEuro] = amount / 100;
    amount %= 100;

    // Calculate the number of 50 cent coins
    coinCount[CoinType.FiftyCent] = amount / 50;
    amount %= 50;

    // Calculate the number of 20 cent coins
    coinCount[CoinType.TwentyCent] = amount / 20;
    amount %= 20;

    // Calculate the number of 10 cent coins
    coinCount[CoinType.TenCent] = amount / 10;

    // Return the coin count dictionary
    return coinCount;
  }
}