using MediatR;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Commands.BuyProduct;

public class BuyProductCommandHandler : IRequestHandler<BuyProductCommand, BuyProductResponse?>
{
  private readonly IProductRepository _productRepository;
  private readonly IUserWalletRepository _userWalletRepository;


  public BuyProductCommandHandler(
    IProductRepository productRepository,
    IUserWalletRepository userWalletRepository)
  {
    _productRepository = productRepository;
    _userWalletRepository = userWalletRepository;
  }

  public Task<BuyProductResponse?> Handle(BuyProductCommand request, CancellationToken cancellationToken)
  {
    var product = _productRepository.GetProductWithName(request.ProductName);

    if (product == null)
    {
      Console.WriteLine($"Product with name {request.ProductName} does not exist.");
      return Task.FromResult<BuyProductResponse?>(null);
    }

    var depositedAmount = _userWalletRepository.TotalAmount();

    if (product.Price > depositedAmount)
    {
      Console.WriteLine("Insufficient amount to buy the product.");
      return Task.FromResult<BuyProductResponse?>(null);
    }

    Console.WriteLine("Thank you.");


    var g = new BuyProductResponse();
    return Task.FromResult<BuyProductResponse?>(g);
  }
}