using MediatR;
using VendingMachine.Application.Features.ShowAvailableProducts;

namespace VendingMachine.Application.Features.GetAvailableProducts;

/// <summary>
/// Query to get all available products.
/// <seealso cref="ShowAvailableProductsQueryHandler"/>
/// </summary>
public class ShowAvailableProductsQuery : IRequest<Unit>
{
}