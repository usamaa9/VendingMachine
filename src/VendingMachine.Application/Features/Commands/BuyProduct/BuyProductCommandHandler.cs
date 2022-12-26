using VendingMachine.Application.Features.Events.ProductBought;

namespace VendingMachine.Application.Features.Commands.BuyProduct;

public class BuyProductCommandHandler : IRequestHandler<BuyProductCommand, Result<Unit>>
{
  private readonly ICommandBus _commandBus;
  private readonly IConsoleWriter _consoleWriter;
  private readonly IMachineWallet _machineWallet;
  private readonly IProductStore _productStore;
  private readonly IUserWallet _userWallet;

  public BuyProductCommandHandler(
    IProductStore productStore,
    IUserWallet userWallet,
    IMachineWallet machineWallet,
    ICommandBus commandBus,
    IConsoleWriter consoleWriter)
  {
    _productStore = productStore;
    _userWallet = userWallet;
    _machineWallet = machineWallet;
    _commandBus = commandBus;
    _consoleWriter = consoleWriter;
  }

  public async Task<Result<Unit>> Handle(BuyProductCommand request,
    CancellationToken cancellationToken)
  {
    // Check if the product name is valid
    var product = _productStore.GetProductWithName(request.ProductName);

    if (product == null)
    {
      _consoleWriter.DisplayMessage($"Product with name {request.ProductName} does not exist.");

      return Result.From(Unit.Value);
    }

    // Check if there are any portions of this product left
    if (product.Portions == 0)
    {
      _consoleWriter.DisplayMessage("Sorry this product is no longer in stock :(");
      return Result.From(Unit.Value);
    }

    // Check if the deposited amount is sufficient
    var change = _userWallet.TotalAmount() - product.Price;

    if (change < 0)
    {
      _consoleWriter.DisplayMessage("Insufficient amount to buy the product.");
      return Result.From(Unit.Value);
    }

    // Check if machine has coins to give change.
    if (!_machineWallet.CanGiveChange(change, out var changeCoins))
    {
      _consoleWriter.DisplayMessage(
        "Sorry, I don't have change for the deposited amount. Please use exact coins for purchase.");
      return Result.From(Unit.Value);
    }

    _consoleWriter.DisplayMessage("Thank you");
    _consoleWriter.PrintChange(changeCoins!);

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