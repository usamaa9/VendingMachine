using MediatR;

namespace VendingMachine.Application.Features.Commands.BuyProduct;

/// <summary>
/// Command to buy a product.
/// <seealso cref="BuyProductCommandHandler"/>
/// </summary>
public class BuyProductCommand : IRequest<BuyProductResponse>
{
  public string? ProductName { get; set; }
}