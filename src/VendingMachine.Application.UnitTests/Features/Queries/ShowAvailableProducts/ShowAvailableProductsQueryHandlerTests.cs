using VendingMachine.Application.Features.Queries.ShowAvailableProducts;

namespace VendingMachine.Application.UnitTests.Features.Queries.ShowAvailableProducts;

public class ShowAvailableProductsQueryHandlerTests
{
  private readonly Mock<IConsoleWriter> _consoleWriter;
  private readonly ShowAvailableProductsQueryHandler _handler;
  private readonly Mock<IProductStore> _productStore;
  private readonly ShowAvailableProductsQuery _validQuery;

  public ShowAvailableProductsQueryHandlerTests()
  {
    _consoleWriter = new Mock<IConsoleWriter>();
    _productStore = new Mock<IProductStore>();
    _handler = new ShowAvailableProductsQueryHandler(
      _productStore.Object, _consoleWriter.Object);
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

    _productStore.Setup(x => x.GetInStockProducts()).Returns(vendingMachineProducts);

    // Act
    await _handler.Handle(_validQuery, CancellationToken.None);

    // Assert
    _consoleWriter.Verify(x => x.DisplayProducts(vendingMachineProducts), Times.Once());
  }
}