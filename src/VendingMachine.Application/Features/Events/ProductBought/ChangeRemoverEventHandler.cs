namespace VendingMachine.Application.Features.Events.ProductBought;

/// <summary>
/// Removes the coins required to return the change to user from the machine wallet.
/// </summary>
public class ChangeRemoverEventHandler : INotificationHandler<ProductBoughtEvent>
{
  private readonly IMachineWallet _machineWallet;

  public ChangeRemoverEventHandler(IMachineWallet machineWallet)
  {
    _machineWallet = machineWallet;
  }

  public Task Handle(ProductBoughtEvent notification, CancellationToken cancellationToken)
  {
    var changeCoins = notification.ChangeCoins!;

    foreach (var coin in changeCoins) _machineWallet.RemoveCoins(coin.Key, coin.Value);

    return Task.CompletedTask;
  }
}