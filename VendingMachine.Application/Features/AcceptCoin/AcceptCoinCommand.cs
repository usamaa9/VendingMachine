using MediatR;
using VendingMachine.Application.Enumerations;

namespace VendingMachine.Application.Features.AcceptCoin;

/// <summary>
/// Command for accepting coins.
/// <seealso cref="AcceptCoinCommandHandler"/>
/// </summary>
public class AcceptCoinCommand : IRequest<Unit>
{
    public CoinType CoinType { get; set; }

    public int Quantity { get; set; }
}
