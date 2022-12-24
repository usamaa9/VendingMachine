using MediatR;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Commands.AcceptCoin;

public class AcceptCoinCommandHandler : IRequestHandler<AcceptCoinCommand, Unit>
{
  private readonly IUserWallet _userWalletRepository;

  public AcceptCoinCommandHandler(
    IUserWallet userWalletRepository)
  {
    _userWalletRepository = userWalletRepository;
  }

  public Task<Unit> Handle(AcceptCoinCommand request, CancellationToken cancellationToken)
  {
    _userWalletRepository.AddCoins(request.CoinType, request.Quantity);

    return Task.FromResult(Unit.Value);
  }
}