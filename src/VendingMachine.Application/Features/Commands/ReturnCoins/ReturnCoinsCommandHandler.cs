namespace VendingMachine.Application.Features.Commands.ReturnCoins;

public class ReturnCoinsCommandHandler : IRequestHandler<ReturnCoinsCommand, Result<Unit>>
{
  private readonly IConsoleWriter _consoleWriter;
  private readonly IUserWallet _userWallet;

  public ReturnCoinsCommandHandler(IUserWallet userWallet, IConsoleWriter consoleWriter)
  {
    _userWallet = userWallet;
    _consoleWriter = consoleWriter;
  }

  public Task<Result<Unit>> Handle(ReturnCoinsCommand request, CancellationToken cancellationToken)
  {
    var coinsToReturn = _userWallet.GetAllCoins().ToDictionary(x => x.Key, x => x.Value);
    _userWallet.RemoveAllCoins();
    _consoleWriter.ReturnedCoinsMessage();
    _consoleWriter.PrintCoins(coinsToReturn);

    return Task.FromResult(Result.From(Unit.Value));
  }
}