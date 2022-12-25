using MediatR;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Events;

public class ProductQuantityReducerEventHandler : INotificationHandler<ProductBoughtEvent>
{
  private readonly IProductStore _productStore;

  public ProductQuantityReducerEventHandler(IProductStore productStore)
  {
    _productStore = productStore;
  }

  public Task Handle(ProductBoughtEvent notification, CancellationToken cancellationToken)
  {
    // Remove one portion from the productStore
    _productStore.RemoveProductWithName(notification.ProductName);

    return Task.CompletedTask;
  }
}