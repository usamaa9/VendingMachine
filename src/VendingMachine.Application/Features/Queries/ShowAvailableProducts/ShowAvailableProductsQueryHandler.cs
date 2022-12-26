namespace VendingMachine.Application.Features.Queries.ShowAvailableProducts;

public class ShowAvailableProductsQueryHandler : IRequestHandler<ShowAvailableProductsQuery, Result<Unit>>
{
  private readonly IConsoleWriter _consoleWriter;
  private readonly IProductStore _productStore;

  public ShowAvailableProductsQueryHandler(IProductStore productStore, IConsoleWriter consoleWriter)
  {
    _productStore = productStore;
    _consoleWriter = consoleWriter;
  }

  public Task<Result<Unit>> Handle(ShowAvailableProductsQuery request,
    CancellationToken cancellationToken)
  {
    // Display all the products here using the productsRepo
    var products = _productStore.GetInStockProducts();

    _consoleWriter.DisplayProducts(products);

    return Task.FromResult(Result.From(Unit.Value));
  }
}