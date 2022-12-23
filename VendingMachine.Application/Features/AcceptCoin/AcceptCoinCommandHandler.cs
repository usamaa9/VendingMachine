using MediatR;
using VendingMachine.Application.Features.Events;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.AcceptCoin;

public class AcceptCoinCommandHandler : IRequestHandler<AcceptCoinCommand, AcceptedCoinEvent>
{
    private readonly IUserWalletRepository _userWalletRepository;
    private readonly IMediator _commandBus;

    public AcceptCoinCommandHandler(
        IUserWalletRepository userWalletRepository,
        IMediator commandBus)
    {
        _userWalletRepository = userWalletRepository;
        _commandBus = commandBus;
    }

    public async Task<AcceptedCoinEvent> Handle(AcceptCoinCommand request, CancellationToken cancellationToken)
    {
        _userWalletRepository.AddCoins(request.CoinType, request.Quantity);

        var acceptedCoinEvent = new AcceptedCoinEvent();

        return await _commandBus.Publish(acceptedCoinEvent);
    }
}
