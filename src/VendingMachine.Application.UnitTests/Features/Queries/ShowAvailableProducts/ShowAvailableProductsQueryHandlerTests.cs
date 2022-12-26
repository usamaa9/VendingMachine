using VendingMachine.Application.Features.Queries.ShowAvailableProducts;

namespace VendingMachine.Application.UnitTests.Features.Queries.ShowAvailableProducts;

public class ShowAvailableProductsQueryHandlerTests
{
  private readonly ShowAvailableProductsQueryHandler _handler;
  private readonly Mock<IConsolePrinter> _mockConsolePrinter;
  private readonly Mock<IProductStore> _mockProductStore;
  private readonly ShowAvailableProductsQuery _validQuery;

  public ShowAvailableProductsQueryHandlerTests()
  {
    _mockConsolePrinter = new Mock<IConsolePrinter>();
    _mockProductStore = new Mock<IProductStore>();
    _handler = new ShowAvailableProductsQueryHandler(
      _mockProductStore.Object, _mockConsolePrinter.Object);
    _validQuery = new ShowAvailableProductsQuery();
  }

  [Fact]
  public async void Handle_DisplaysInStockProducts()
  {
    // Arrange
    var vendingMachineProducts = new List<VendingMachineProduct>
    {
      new() { Name = "Candy", Price = 50, Portions = 2 },
      new() { Name = "Soda", Price = 100, Portions = 3 }
    };

    _mockProductStore.Setup(x => x.GetInStockProducts()).Returns(vendingMachineProducts);

    // Act
    await _handler.Handle(_validQuery, CancellationToken.None);

    // Assert
    _mockConsolePrinter.Verify(x => x.DisplayProducts(vendingMachineProducts), Times.Once());
  }
}