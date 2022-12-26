using VendingMachine.Application.Features.Events.ProductBought;

namespace VendingMachine.Application.UnitTests.Features.Events.ProductBought;

public class ProductQuantityReducerEventHandlerTests
{
  private readonly ProductQuantityReducerEventHandler _handler;
  private readonly Mock<IProductStore> _productStore;
  private readonly ProductBoughtEvent _validEvent;

  public ProductQuantityReducerEventHandlerTests()
  {
    _productStore = new Mock<IProductStore>();
    _handler = new ProductQuantityReducerEventHandler(_productStore.Object);
    _validEvent = new ProductBoughtEvent
    {
      ProductName = "Candy"
    };
  }

  [Fact]
  public async void Handle_RemovesOnePortionFromProductStore()
  {
    // Act
    await _handler.Handle(_validEvent, CancellationToken.None);

    // Assert
    _productStore.Verify(
      x => x.RemoveProductWithName(_validEvent.ProductName),
      Times.Once());
  }
}