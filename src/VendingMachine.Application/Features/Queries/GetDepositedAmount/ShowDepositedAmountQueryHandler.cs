using MediatR;
using VendingMachine.Application.IOHelpers;
using VendingMachine.Application.Models;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Queries.GetDepositedAmount;

public class ShowDepositedAmountQueryHandler : IRequestHandler<ShowDepositedAmountQuery, Result<Unit>>
{
  private readonly IUserWallet _userWallet;
  private readonly IConsolePrinter _consolePrinter;

  public ShowDepositedAmountQueryHandler(IUserWallet userWallet, IConsolePrinter consolePrinter)
  {
    _userWallet = userWallet;
    _consolePrinter = consolePrinter;
  }

  public Task<Result<Unit>> Handle(ShowDepositedAmountQuery request,
    CancellationToken cancellationToken)
  {
    var coins = _userWallet.GetAllCoins();

    _consolePrinter.PrintCoinsInWallet(coins);

    return Task.FromResult(Result.From(Unit.Value));
  }
}