namespace VendingMachine.Application.Features.Commands.AcceptCoin;

/// <summary>
/// Command for accepting coins.
/// <seealso cref="AcceptCoinCommandHandler"/>
/// </summary>
public class AcceptCoinCommand : IRequest<Result<Unit>>
{
  public CoinType CoinType { get; set; }

  public int Quantity { get; set; }
}