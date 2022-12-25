using MediatR;
using VendingMachine.Application.Entities;
using VendingMachine.Application.Models;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Queries.ShowAvailableProducts;

internal class
  ShowAvailableProductsQueryHandler : IRequestHandler<ShowAvailableProductsQuery, Result<List<VendingMachineProduct>>>
{
  private readonly IProductStore _productStore;

  public ShowAvailableProductsQueryHandler(IProductStore productStore)
  {
    _productStore = productStore;
  }

  public Task<Result<List<VendingMachineProduct>>> Handle(ShowAvailableProductsQuery request,
    CancellationToken cancellationToken)
  {
    // Display all the products here using the productsRepo
    var products = _productStore.GetInStockProducts();

    var result = Result.From(products);

    return Task.FromResult(result);
  }
}