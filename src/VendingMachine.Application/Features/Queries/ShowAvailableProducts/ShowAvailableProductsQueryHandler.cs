using MediatR;
using VendingMachine.Application.IOHelpers;
using VendingMachine.Application.Models;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Queries.ShowAvailableProducts;

internal class
  ShowAvailableProductsQueryHandler : IRequestHandler<ShowAvailableProductsQuery, Result<Unit>>
{
  private readonly IProductStore _productStore;
  private readonly IConsolePrinter _consolePrinter;

  public ShowAvailableProductsQueryHandler(IProductStore productStore, IConsolePrinter consolePrinter)
  {
    _productStore = productStore;
    _consolePrinter = consolePrinter;
  }

  public Task<Result<Unit>> Handle(ShowAvailableProductsQuery request,
    CancellationToken cancellationToken)
  {
    // Display all the products here using the productsRepo
    var products = _productStore.GetInStockProducts();

    _consolePrinter.DisplayProducts(products);

    return Task.FromResult(Result.From(Unit.Value));
  }
}