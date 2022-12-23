using MediatR;

namespace VendingMachine.Application.Features.GetAvailableProducts
{
    /// <summary>
    /// Query to get all available products.
    /// <seealso cref="GetAvailableProductsQueryHandler"/>
    /// </summary>
    public class GetAvailableProductsQuery : IRequest<Unit>
    {
    }
}
