using MediatR;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Queries.ShowAvailableProducts;

internal class ShowAvailableProductsQueryHandler : IRequestHandler<ShowAvailableProductsQuery, Unit>
{
  private readonly IProductStore _productStore;

  public ShowAvailableProductsQueryHandler(IProductStore productStore)
  {
    _productStore = productStore;
  }

  public Task<Unit> Handle(ShowAvailableProductsQuery request, CancellationToken cancellationToken)
  {
    // Display all the products here using the productsRepo
    _productStore.DisplayAllProducts();
    return Task.FromResult(Unit.Value);
  }
}