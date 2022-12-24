using MediatR;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Queries.ShowDepositedAmount;

public class ShowDepositedAmountQueryHandler : IRequestHandler<ShowDepositedAmountQuery, Unit>
{
  private readonly IUserWalletRepository _userWalletRepository;

  public ShowDepositedAmountQueryHandler(IUserWalletRepository userWalletRepository)
  {
    _userWalletRepository = userWalletRepository;
  }

  public Task<Unit> Handle(ShowDepositedAmountQuery request, CancellationToken cancellationToken)
  {
    _userWalletRepository.DisplayCoins();

    return Task.FromResult(Unit.Value);
  }
}