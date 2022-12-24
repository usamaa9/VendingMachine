using MediatR;
using VendingMachine.Application.Mediator;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Commands.BuyProduct;

public class BuyProductCommandHandler : IRequestHandler<BuyProductCommand, Unit>
{
  private readonly ICommandBus _commandBus;
  private readonly IProductStore _productRepository;
  private readonly IUserWallet _userWalletRepository;


  public BuyProductCommandHandler(
    IProductStore productRepository,
    IUserWallet userWalletRepository,
    ICommandBus commandBus)
  {
    _productRepository = productRepository;
    _userWalletRepository = userWalletRepository;
    _commandBus = commandBus;
  }

  public Task<Unit> Handle(BuyProductCommand request, CancellationToken cancellationToken)
  {
    var product = _productRepository.GetProductWithName(request.ProductName);

    if (product == null)
    {
      Console.WriteLine($"Product with name {request.ProductName} does not exist.");

      return Task.FromResult(Unit.Value);
    }

    var depositedAmount = _userWalletRepository.TotalAmount();

    if (product.Price > depositedAmount)
    {
      Console.WriteLine("Insufficient amount to buy the product.");
      return Task.FromResult(Unit.Value);
    }

    Console.WriteLine("Thank you.");


    return Task.FromResult(Unit.Value);
  }
}