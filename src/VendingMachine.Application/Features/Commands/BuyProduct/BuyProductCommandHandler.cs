using MediatR;
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


    // calculate the change which should be returned

    // remove those coins from the machine wallet

    // output the amount and type of coins to the console.


    return Task.FromResult(Unit.Value);
  }
}