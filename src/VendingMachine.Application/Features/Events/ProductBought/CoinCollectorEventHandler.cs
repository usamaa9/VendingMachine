using MediatR;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Events.ProductBought;

public class CoinCollectorEventHandler : INotificationHandler<ProductBoughtEvent>
{
  private readonly IMachineWallet _machineWallet;
  private readonly IUserWallet _userWallet;

  public CoinCollectorEventHandler(IUserWallet userWallet, IMachineWallet machineWallet)
  {
    _userWallet = userWallet;
    _machineWallet = machineWallet;
  }

  public Task Handle(ProductBoughtEvent notification, CancellationToken cancellationToken)
  {
    // add all the user wallet coins to the machine wallet and clear the user wallet
    foreach (var coin in notification.UserCoins!) _machineWallet.AddCoins(coin.Key, coin.Value);

    _userWallet.RemoveAllCoins();

    return Task.CompletedTask;
  }
}