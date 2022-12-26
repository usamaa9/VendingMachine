using MediatR;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Events.ProductBought;

public class ChangeCalculatorEventHandler : INotificationHandler<ProductBoughtEvent>
{
  private readonly IMachineWallet _machineWallet;

  public ChangeCalculatorEventHandler(IMachineWallet machineWallet)
  {
    _machineWallet = machineWallet;
  }

  public Task Handle(ProductBoughtEvent notification, CancellationToken cancellationToken)
  {
    var changeCoins = notification.ChangeCoins!;

    // remove coins required for change from the machine wallet.
    foreach (var coin in changeCoins) _machineWallet.RemoveCoins(coin.Key, coin.Value);

    return Task.CompletedTask;
  }
}