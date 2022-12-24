using MediatR;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Commands.ReturnCoins;

public class ReturnCoinsCommandHandler : IRequestHandler<ReturnCoinsCommand, Unit>
{
  private readonly IUserWalletRepository _userWalletRepository;

  public ReturnCoinsCommandHandler(IUserWalletRepository userWalletRepository)
  {
    _userWalletRepository = userWalletRepository;
  }

  public Task<Unit> Handle(ReturnCoinsCommand request, CancellationToken cancellationToken)
  {
    Console.WriteLine("Returning all coins to user.");
    _userWalletRepository.RemoveAllCoins();
    return Task.FromResult(Unit.Value);
  }
}