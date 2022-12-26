using Moq;
using VendingMachine.Application.Features.Events.ProductBought;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.UnitTests.Features.Events.ProductBought;

public class ProductQuantityReducerEventHandlerTests
{
  private readonly ProductQuantityReducerEventHandler _handler;
  private readonly Mock<IProductStore> _mockProductStore;
  private readonly ProductBoughtEvent _validEvent;

  public ProductQuantityReducerEventHandlerTests()
  {
    _mockProductStore = new Mock<IProductStore>();
    _handler = new ProductQuantityReducerEventHandler(_mockProductStore.Object);
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
    _mockProductStore.Verify(
      x => x.RemoveProductWithName(_validEvent.ProductName),
      Times.Once());
  }
}