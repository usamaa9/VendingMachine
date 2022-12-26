namespace VendingMachine.Infrastructure.UnitTests.Persistence;

public class ProductStoreTests
{
  private readonly ProductStore _store;

  public ProductStoreTests()
  {
    _store = new ProductStore();
  }

  [Fact]
  public void CanGetProductWithName()
  {
    // Arrange
    var product = new VendingMachineProduct
    {
      Name = "Chips"
    };
    _store.AddProduct(product);

    // Act
    var result = _store.GetProductWithName("chips");

    // Assert
    Assert.NotNull(result);
  }

  [Fact]
  public void CanGetNullForNonexistentProduct()
  {
    // Arrange & Act
    var result = _store.GetProductWithName("soda");

    // Assert
    Assert.Null(result);
  }

  [Fact]
  public void CanRemoveOnePortionOfProduct()
  {
    // Arrange
    var product = new VendingMachineProduct
    {
      Name = "Chips",
      Portions = 5
    };
    _store.AddProduct(product);

    // Act
    _store.RemoveProductWithName("chips");

    // Assert
    Assert.Equal(4, product.Portions);
  }

  [Theory]
  [InlineData("")]
  [InlineData(null)]
  [InlineData("random")]
  public void RemoveProductWithName_NullOrEmptyProductName_DoesNothing(string name)
  {
    // Arrange
    var product = new VendingMachineProduct
    {
      Name = "Chips",
      Portions = 5
    };
    _store.AddProduct(product);

    // Act
    _store.RemoveProductWithName(name);

    // Assert
    Assert.Equal(5, product.Portions);
  }

  [Fact]
  public void CanGetInStockProducts()
  {
    // Arrange
    var product1 = new VendingMachineProduct
    {
      Name = "Chips",
      Portions = 5
    };
    _store.AddProduct(product1);
    var product2 = new VendingMachineProduct
    {
      Name = "Soda",
      Portions = 0
    };
    _store.AddProduct(product2);

    // Act
    var inStockProducts = _store.GetInStockProducts();

    // Assert
    Assert.Single(inStockProducts);
    Assert.Equal("Chips", inStockProducts[0].Name);
  }
}