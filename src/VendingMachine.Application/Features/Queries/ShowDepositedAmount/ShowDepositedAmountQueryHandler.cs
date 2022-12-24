using MediatR;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Queries.ShowDepositedAmount;

public class ShowDepositedAmountQueryHandler : IRequestHandler<ShowDepositedAmountQuery, Unit>
{
  private readonly IUserWallet _userWallet;

  public ShowDepositedAmountQueryHandler(IUserWallet userWallet)
  {
    _userWallet = userWallet;
  }

  public Task<Unit> Handle(ShowDepositedAmountQuery request, CancellationToken cancellationToken)
  {
    _userWallet.DisplayCoins();

    return Task.FromResult(Unit.Value);
  }
}