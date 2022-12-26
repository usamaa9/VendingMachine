using MediatR;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Events.ProductBought;

/// <summary>
/// Collects all of the user coins when they buy a product.
/// </summary>
public class CollectUserCoinsEventHandler : INotificationHandler<ProductBoughtEvent>
{
  private readonly IMachineWallet _machineWallet;
  private readonly IUserWallet _userWallet;

  public CollectUserCoinsEventHandler(IUserWallet userWallet, IMachineWallet machineWallet)
  {
    _userWallet = userWallet;
    _machineWallet = machineWallet;
  }

  public Task Handle(ProductBoughtEvent notification, CancellationToken cancellationToken)
  {
    // add all the user wallet coins to the machine wallet
    foreach (var coin in notification.UserCoins!) _machineWallet.AddCoins(coin.Key, coin.Value);

    // clear the user wallet
    _userWallet.RemoveAllCoins();

    return Task.CompletedTask;
  }
}