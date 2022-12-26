namespace VendingMachine.Application.Features.Queries.ShowAvailableProducts;

public class ShowAvailableProductsQueryHandler : IRequestHandler<ShowAvailableProductsQuery, Result<Unit>>
{
  private readonly IConsolePrinter _consolePrinter;
  private readonly IProductStore _productStore;

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