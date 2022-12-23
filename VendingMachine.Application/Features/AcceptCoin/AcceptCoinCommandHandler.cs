using MediatR;

namespace VendingMachine.Application.Features.AcceptCoin;

public class AcceptCoinCommandHandler : IRequestHandler<AcceptCoinCommand, Unit>
{
    public AcceptCoinCommandHandler()
    {
    }

    public Task<Unit> Handle(AcceptCoinCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
