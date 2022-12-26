namespace VendingMachine.Application.Features.Queries.ShowDepositedAmount;

public class ShowDepositedAmountQueryHandler : IRequestHandler<ShowDepositedAmountQuery, Result<Unit>>
{
  private readonly IConsoleWriter _consoleWriter;
  private readonly IUserWallet _userWallet;

  public ShowDepositedAmountQueryHandler(IUserWallet userWallet, IConsoleWriter consoleWriter)
  {
    _userWallet = userWallet;
    _consoleWriter = consoleWriter;
  }

  public Task<Result<Unit>> Handle(ShowDepositedAmountQuery request,
    CancellationToken cancellationToken)
  {
    var coins = _userWallet.GetAllCoins();

    _consoleWriter.PrintCoins(coins);

    return Task.FromResult(Result.From(Unit.Value));
  }
}