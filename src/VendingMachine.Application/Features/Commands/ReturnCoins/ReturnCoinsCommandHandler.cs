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
    _userWallet.RemoveAllCoins();
    _consoleWriter.ReturnedCoinsMessage();

    return Task.FromResult(Result.From(Unit.Value));
  }
}