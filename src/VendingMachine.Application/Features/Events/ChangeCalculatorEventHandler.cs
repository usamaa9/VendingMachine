using MediatR;
using VendingMachine.Application.Extensions;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Events;

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
    // remove those coins from the machine wallet
    foreach (var coin in changeCoins) _machineWallet.RemoveCoins(coin.Key, coin.Value);

    // output the amount and type of coins to the console.
    Console.WriteLine("Your Change");

    changeCoins.DisplayCoins();

    return Task.CompletedTask;
  }
}