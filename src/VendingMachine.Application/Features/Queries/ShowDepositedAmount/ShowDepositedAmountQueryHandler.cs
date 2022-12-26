namespace VendingMachine.Application.Features.Queries.ShowDepositedAmount;

public class ShowDepositedAmountQueryHandler : IRequestHandler<ShowDepositedAmountQuery, Result<Unit>>
{
  private readonly IConsolePrinter _consolePrinter;
  private readonly IUserWallet _userWallet;

  public ShowDepositedAmountQueryHandler(IUserWallet userWallet, IConsolePrinter consolePrinter)
  {
    _userWallet = userWallet;
    _consolePrinter = consolePrinter;
  }

  public Task<Result<Unit>> Handle(ShowDepositedAmountQuery request,
    CancellationToken cancellationToken)
  {
    var coins = _userWallet.GetAllCoins();

    _consolePrinter.PrintCoins(coins);

    return Task.FromResult(Result.From(Unit.Value));
  }
}