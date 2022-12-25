using MediatR;
using VendingMachine.Application.Features.Events;
using VendingMachine.Application.Mediator;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Commands.BuyProduct;

public class BuyProductCommandHandler : IRequestHandler<BuyProductCommand, Unit>
{
  private readonly ICommandBus _commandBus;
  private readonly IMachineWallet _machineWallet;
  private readonly IProductStore _productStore;
  private readonly IUserWallet _userWallet;


  public BuyProductCommandHandler(
    IProductStore productStore,
    IUserWallet userWallet,
    IMachineWallet machineWallet,
    ICommandBus commandBus)
  {
    _productStore = productStore;
    _userWallet = userWallet;
    _machineWallet = machineWallet;
    _commandBus = commandBus;
  }

  public async Task<Unit> Handle(BuyProductCommand request, CancellationToken cancellationToken)
  {
    // Check if the product name is valid
    var product = _productStore.GetProductWithName(request.ProductName);

    if (product == null)
    {
      Console.WriteLine($"Product with name {request.ProductName} does not exist.");

      return Unit.Value;
    }

    // Check if there are any portions of this product left
    if (product.Portions == 0)
    {
      Console.WriteLine("Sorry this product is no longer in stock :(");
      Console.WriteLine();
      return Unit.Value;
    }

    // Check if the deposited amount is sufficient
    var depositedAmount = _userWallet.TotalAmount();
    var change = depositedAmount - product.Price;


    if (change < 0)
    {
      Console.WriteLine("Insufficient amount to buy the product.");
      return Unit.Value;
    }


    // Check if machine has coins to give change.
    if (!_machineWallet.CanGiveChange(change, out var changeCoins))
    {
      Console.WriteLine("Sorry, I don't have change for the deposited amount. Please use exact coins for purchase.");
      return Unit.Value;
    }

    Console.WriteLine("Thank you.");

    // Publish the ProductBoughtEvent
    await _commandBus.PublishAsync(new ProductBoughtEvent
    {
      ProductName = product.Name,
      UserCoins = _userWallet.GetCoins(),
      ChangeCoins = changeCoins
    });


    return Unit.Value;
  }
}