using MediatR;
using VendingMachine.Application.Models;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Commands.AcceptCoin;

public class AcceptCoinCommandHandler : IRequestHandler<AcceptCoinCommand, Result<Unit>>
{
  private readonly IUserWallet _userWallet;

  public AcceptCoinCommandHandler(
    IUserWallet userWallet)
  {
    _userWallet = userWallet;
  }

  public Task<Result<Unit>> Handle(AcceptCoinCommand request, CancellationToken cancellationToken)
  {
    _userWallet.AddCoins(request.CoinType, request.Quantity);

    return Task.FromResult(Result.From(Unit.Value));
  }
}