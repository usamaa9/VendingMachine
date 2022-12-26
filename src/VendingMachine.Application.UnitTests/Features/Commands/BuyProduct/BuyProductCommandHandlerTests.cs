using Moq;
using VendingMachine.Application.Entities;
using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Features.Commands.BuyProduct;
using VendingMachine.Application.Features.Events.ProductBought;
using VendingMachine.Application.IOHelpers;
using VendingMachine.Application.Mediator;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.UnitTests.Features.Commands.BuyProduct;

public class BuyProductCommandHandlerTests
{
  private readonly Mock<ICommandBus> _commandBus;
  private readonly Mock<IConsolePrinter> _consolePrinter;
  private readonly Mock<IMachineWallet> _machineWallet;
  private readonly Mock<IProductStore> _productStore;
  private readonly BuyProductCommandHandler _sut;
  private readonly Mock<IUserWallet> _userWallet;
  private readonly BuyProductCommand _validCommand;
  private readonly VendingMachineProduct _validProduct;

  public BuyProductCommandHandlerTests()
  {
    _commandBus = new Mock<ICommandBus>();
    _consolePrinter = new Mock<IConsolePrinter>();
    _machineWallet = new Mock<IMachineWallet>();
    _productStore = new Mock<IProductStore>();
    _userWallet = new Mock<IUserWallet>();
    _sut = new BuyProductCommandHandler(
      _productStore.Object, _userWallet.Object, _machineWallet.Object,
      _commandBus.Object, _consolePrinter.Object);
    _validCommand = new BuyProductCommand
    {
      ProductName = "chocolate bar"
    };
    _validProduct = new VendingMachineProduct
    {
      Name = "chocolate bar",
      Portions = 3,
      Price = 50
    };
  }

  [Fact]
  public async void Handle_InvalidProductName_DisplaysMessage()
  {
    // Arrange
    var invalidCommand = new BuyProductCommand
    {
      ProductName = "invalid product name"
    };

    _productStore.Setup(x => x.GetProductWithName(invalidCommand.ProductName)).Returns((VendingMachineProduct?)null);

    // Act
    await _sut.Handle(invalidCommand, CancellationToken.None);

    // Assert
    _consolePrinter.Verify(
      x => x.DisplayMessage(It.Is<string>(
        message => message.Contains($"Product with name {invalidCommand.ProductName} does not exist."))),
      Times.Once());
    _commandBus.Verify(x => x.PublishAsync(It.IsAny<ProductBoughtEvent>()), Times.Never);
  }

  [Fact]
  public async void Handle_OutOfStockProduct_DisplaysMessage()
  {
    // Arrange
    _validProduct.Portions = 0;
    _productStore.Setup(x => x.GetProductWithName(_validCommand.ProductName))
      .Returns(_validProduct);

    // Act
    await _sut.Handle(_validCommand, CancellationToken.None);

    // Assert
    _consolePrinter.Verify(
      x => x.DisplayMessage(It.Is<string>(
        message => message.Contains("Sorry this product is no longer in stock :("))),
      Times.Once());
    _commandBus.Verify(x => x.PublishAsync(It.IsAny<ProductBoughtEvent>()), Times.Never);
  }

  [Fact]
  public async void Handle_InsufficientAmount_DisplaysMessage()
  {
    // Arrange
    _validProduct.Price = 100;
    _productStore.Setup(x => x.GetProductWithName(_validCommand.ProductName))
      .Returns(_validProduct);
    _userWallet.Setup(x => x.TotalAmount()).Returns(49);

    // Act
    await _sut.Handle(_validCommand, CancellationToken.None);

    // Assert
    _consolePrinter.Verify(
      x => x.DisplayMessage(It.Is<string>(
        message => message.Contains("Insufficient amount to buy the product"))),
      Times.Once());
    _commandBus.Verify(x => x.PublishAsync(It.IsAny<ProductBoughtEvent>()), Times.Never);
  }

  [Fact]
  public async void Handle_MachineCannotGiveChange_DisplaysMessage()
  {
    // Arrange
    var coins = It.IsAny<Dictionary<CoinType, int>>();
    _validProduct.Price = 50;
    _productStore.Setup(x => x.GetProductWithName(_validCommand.ProductName))
      .Returns(_validProduct);
    _userWallet.Setup(x => x.TotalAmount()).Returns(100);
    _machineWallet.Setup(x => x.CanGiveChange(50, out coins))
      .Returns(false);

    // Act
    await _sut.Handle(_validCommand, CancellationToken.None);

    // Assert
    _consolePrinter.Verify(
      x => x.DisplayMessage(It.Is<string>(
        message => message.Contains(
          "Sorry, I don't have change for the deposited amount. Please use exact coins for purchase."))),
      Times.Once());
    _commandBus.Verify(x => x.PublishAsync(It.IsAny<ProductBoughtEvent>()), Times.Never);
  }

  [Fact]
  public async void Handle_ValidRequest_DisplaysThankYouMessage()
  {
    // Arrange
    var coins = It.IsAny<Dictionary<CoinType, int>>();

    _validProduct.Price = 50;
    _productStore.Setup(x => x.GetProductWithName(_validCommand.ProductName))
      .Returns(_validProduct);
    _userWallet.Setup(x => x.TotalAmount()).Returns(100);
    _machineWallet.Setup(x => x.CanGiveChange(50, out coins))
      .Returns(true);

    // Act
    await _sut.Handle(_validCommand, CancellationToken.None);

    // Assert
    _consolePrinter.Verify(
      x => x.DisplayMessage(It.Is<string>(
        message => message.Contains("Thank you"))),
      Times.Once());
    _consolePrinter.Verify(
      x => x.PrintChange(It.IsAny<Dictionary<CoinType, int>>()), Times.Once());
  }
}