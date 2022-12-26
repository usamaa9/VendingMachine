using MediatR;
using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Models;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Queries.GetDepositedAmount;

public class
  GetDepositedAmountQueryHandler : IRequestHandler<GetDepositedAmountQuery, Result<Dictionary<CoinType, int>>>
{
  private readonly IUserWallet _userWallet;

  public GetDepositedAmountQueryHandler(IUserWallet userWallet)
  {
    _userWallet = userWallet;
  }

  public Task<Result<Dictionary<CoinType, int>>> Handle(GetDepositedAmountQuery request,
    CancellationToken cancellationToken)
  {
    var coins = _userWallet.GetAllCoins();

    return Task.FromResult(Result.From(coins));
  }
}