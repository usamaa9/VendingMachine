using MediatR;
using VendingMachine.Application.Features.Events.CoinsAccepted;
using VendingMachine.Application.Mediator;
using VendingMachine.Application.Models;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Commands.AcceptCoin;

public class AcceptCoinCommandHandler : IRequestHandler<AcceptCoinCommand, Result<Unit>>
{
  private readonly ICommandBus _commandBus;
  private readonly IUserWallet _userWallet;

  public AcceptCoinCommandHandler(
    IUserWallet userWallet,
    ICommandBus commandBus)
  {
    _userWallet = userWallet;
    _commandBus = commandBus;
  }

  public async Task<Result<Unit>> Handle(AcceptCoinCommand request, CancellationToken cancellationToken)
  {
    _userWallet.AddCoins(request.CoinType, request.Quantity);

    var coinsAcceptedEvent = new CoinsAcceptedEvent
    {
      CoinType = request.CoinType,
      Quantity = request.Quantity
    };

    await _commandBus.PublishAsync(coinsAcceptedEvent);

    return Result.From(Unit.Value);
  }
}