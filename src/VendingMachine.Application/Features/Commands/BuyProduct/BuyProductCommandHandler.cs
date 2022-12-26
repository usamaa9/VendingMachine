using MediatR;
using VendingMachine.Application.Features.Events.ProductBought;
using VendingMachine.Application.IOHelpers;
using VendingMachine.Application.Mediator;
using VendingMachine.Application.Models;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Commands.BuyProduct;

public class BuyProductCommandHandler : IRequestHandler<BuyProductCommand, Result<Unit>>
{
  private readonly ICommandBus _commandBus;
  private readonly IConsolePrinter _consolePrinter;
  private readonly IMachineWallet _machineWallet;
  private readonly IProductStore _productStore;
  private readonly IUserWallet _userWallet;

  public BuyProductCommandHandler(
    IProductStore productStore,
    IUserWallet userWallet,
    IMachineWallet machineWallet,
    ICommandBus commandBus,
    IConsolePrinter consolePrinter)
  {
    _productStore = productStore;
    _userWallet = userWallet;
    _machineWallet = machineWallet;
    _commandBus = commandBus;
    _consolePrinter = consolePrinter;
  }

  public async Task<Result<Unit>> Handle(BuyProductCommand request,
    CancellationToken cancellationToken)
  {
    // Check if the product name is valid
    var product = _productStore.GetProductWithName(request.ProductName);

    if (product == null)
    {
      _consolePrinter.DisplayMessage($"Product with name {request.ProductName} does not exist.");

      return Result.From(Unit.Value);
    }

    // Check if there are any portions of this product left
    if (product.Portions == 0)
    {
      _consolePrinter.DisplayMessage("Sorry this product is no longer in stock :(");
      return Result.From(Unit.Value);
    }

    // Check if the deposited amount is sufficient
    var change = _userWallet.TotalAmount() - product.Price;

    if (change < 0)
    {
      _consolePrinter.DisplayMessage("Insufficient amount to buy the product.");
      return Result.From(Unit.Value);
    }

    // Check if machine has coins to give change.
    if (!_machineWallet.CanGiveChange(change, out var changeCoins))
    {
      _consolePrinter.DisplayMessage(
        "Sorry, I don't have change for the deposited amount. Please use exact coins for purchase.");
      return Result.From(Unit.Value);
    }

    _consolePrinter.DisplayMessage("Thank you");
    _consolePrinter.PrintChange(changeCoins!);

    // Publish the ProductBoughtEvent
    await _commandBus.PublishAsync(new ProductBoughtEvent
    {
      ProductName = product.Name,
      UserCoins = _userWallet.GetAllCoins(),
      ChangeCoins = changeCoins
    });


    return Result.From(Unit.Value);
  }
}