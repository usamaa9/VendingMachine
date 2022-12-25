using MediatR;
using VendingMachine.Application.Models;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Queries.ShowDepositedAmount;

public class ShowDepositedAmountQueryHandler : IRequestHandler<ShowDepositedAmountQuery, Result<Unit>>
{
  private readonly IUserWallet _userWallet;

  public ShowDepositedAmountQueryHandler(IUserWallet userWallet)
  {
    _userWallet = userWallet;
  }

  public Task<Result<Unit>> Handle(ShowDepositedAmountQuery request, CancellationToken cancellationToken)
  {
    _userWallet.DisplayCoins();

    return Task.FromResult(Result.From(Unit.Value));
  }
}