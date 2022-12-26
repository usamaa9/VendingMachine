using MediatR;
using VendingMachine.Application.Features.Events;
using VendingMachine.Application.Mediator;
using VendingMachine.Application.Models;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Commands.BuyProduct;

public class BuyProductCommandHandler : IRequestHandler<BuyProductCommand, Result<string>>
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

  public async Task<Result<string>> Handle(BuyProductCommand request, CancellationToken cancellationToken)
  {
    // Check if the product name is valid
    var product = _productStore.GetProductWithName(request.ProductName);

    if (product == null) return Result.From($"Product with name {request.ProductName} does not exist.");

    // Check if there are any portions of this product left
    if (product.Portions == 0) return Result.From("Sorry this product is no longer in stock :(");

    // Check if the deposited amount is sufficient
    var change = _userWallet.TotalAmount() - product.Price;

    if (change < 0) return Result.From("Insufficient amount to buy the product.");


    // Check if machine has coins to give change.
    if (!_machineWallet.CanGiveChange(change, out var changeCoins))
      return Result.From("Sorry, I don't have change for the deposited amount. Please use exact coins for purchase.");


    // Publish the ProductBoughtEvent
    await _commandBus.PublishAsync(new ProductBoughtEvent
    {
      ProductName = product.Name,
      UserCoins = _userWallet.GetAllCoins(),
      ChangeCoins = changeCoins
    });


    return Result.From("Thank you.");
  }
}