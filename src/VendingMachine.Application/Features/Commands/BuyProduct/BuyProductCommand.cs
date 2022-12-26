using MediatR;
using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Models;

namespace VendingMachine.Application.Features.Commands.BuyProduct;

/// <summary>
/// Command to buy a product.
/// <seealso cref="BuyProductCommandHandler"/>
/// </summary>
public class BuyProductCommand : IRequest<Result<Dictionary<CoinType, int>?>>
{
  public string? ProductName { get; set; }
}