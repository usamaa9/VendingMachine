using MediatR;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Commands.ReturnCoins;

public class ReturnCoinsCommandHandler : IRequestHandler<ReturnCoinsCommand, Unit>
{
  private readonly IUserWallet _userWallet;

  public ReturnCoinsCommandHandler(IUserWallet userWallet)
  {
    _userWallet = userWallet;
  }

  public Task<Unit> Handle(ReturnCoinsCommand request, CancellationToken cancellationToken)
  {
    Console.WriteLine("Returning all coins to user.");
    _userWallet.RemoveAllCoins();
    return Task.FromResult(Unit.Value);
  }
}