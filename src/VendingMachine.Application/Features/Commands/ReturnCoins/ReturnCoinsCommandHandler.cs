using MediatR;
using VendingMachine.Application.IOHelpers;
using VendingMachine.Application.Models;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Commands.ReturnCoins;

public class ReturnCoinsCommandHandler : IRequestHandler<ReturnCoinsCommand, Result<Unit>>
{
  private readonly IConsolePrinter _consolePrinter;
  private readonly IUserWallet _userWallet;

  public ReturnCoinsCommandHandler(IUserWallet userWallet, IConsolePrinter consolePrinter)
  {
    _userWallet = userWallet;
    _consolePrinter = consolePrinter;
  }

  public Task<Result<Unit>> Handle(ReturnCoinsCommand request, CancellationToken cancellationToken)
  {
    _userWallet.RemoveAllCoins();
    _consolePrinter.ReturnedCoinsMessage();

    return Task.FromResult(Result.From(Unit.Value));
  }
}