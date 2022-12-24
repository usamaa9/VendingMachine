using MediatR;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Queries.ShowAvailableProducts;

internal class ShowAvailableProductsQueryHandler : IRequestHandler<ShowAvailableProductsQuery, Unit>
{
  private readonly IProductRepository _productRepository;

  public ShowAvailableProductsQueryHandler(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }

  public Task<Unit> Handle(ShowAvailableProductsQuery request, CancellationToken cancellationToken)
  {
    // Display all the products here using the productsRepo
    _productRepository.DisplayAllProducts();
    return Task.FromResult(Unit.Value);
  }
}