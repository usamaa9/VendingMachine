using MediatR;
using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Features.Events;

namespace VendingMachine.Application.Features.AcceptCoin;

/// <summary>
/// Command for accepting coins.
/// <seealso cref="AcceptCoinCommandHandler"/>
/// </summary>
public class AcceptCoinCommand : IRequest<AcceptedCoinEvent>
{
    public CoinType CoinType { get; set; }

    public int Quantity { get; set; }
}
