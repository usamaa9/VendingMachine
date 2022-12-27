using VendingMachine.Application.Features.Commands.AcceptCoin;
using VendingMachine.Application.Features.Commands.BuyProduct;
using VendingMachine.Application.Features.Commands.ReturnCoins;
using VendingMachine.Application.Features.Queries.ShowAvailableProducts;
using VendingMachine.Application.Features.Queries.ShowDepositedAmount;
using VendingMachine.Application.Mediator;
using VendingMachine.ConsoleApp.Main;

namespace VendingMachine.ConsoleApp.UnitTests.Main;

public class AppTests
{
  private readonly Mock<ICommandBus> _commandBus;
  private readonly Mock<IConsoleWriter> _consoleWriter;

  private readonly App _sut;
  private readonly Mock<IUserInput> _userInput;

  public AppTests()
  {
    _commandBus = new Mock<ICommandBus>();
    _consoleWriter = new Mock<IConsoleWriter>();
    _userInput = new Mock<IUserInput>();
    _sut = new App(_commandBus.Object, _consoleWriter.Object, _userInput.Object);
  }

  [Fact]
  public async Task Run_DisplaysMenu()
  {
    // Arrange
    _userInput.Setup(x => x.GetUserMenuChoice()).Returns(MenuOption.Exit);

    // Act
    await _sut.Run();

    // Assert
    _consoleWriter.Verify(x => x.DisplayMenu(), Times.Once);
  }

  [Fact]
  public async Task Run_WithInvalidChoice_DisplaysErrorMessage()
  {
    // Arrange
    _userInput.SetupSequence(x => x.GetUserMenuChoice())
      .Returns((MenuOption)7)
      .Returns(MenuOption.Exit);

    // Act
    await _sut.Run();

    // Assert
    _consoleWriter.Verify(x => x.InvalidMenuChoiceMessage(), Times.Once);
  }

  [Theory]
  [InlineData(MenuOption.InsertCoins)]
  [InlineData(MenuOption.ReturnCoins)]
  [InlineData(MenuOption.BuyProduct)]
  [InlineData(MenuOption.ShowAvailableProducts)]
  [InlineData(MenuOption.ShowDepositedAmount)]
  public async Task Run_ShouldExecuteCorrectMethodForMenuOption(MenuOption menuOption)
  {
    // Arrange
    _userInput.SetupSequence(x => x.GetUserMenuChoice())
      .Returns(menuOption)
      .Returns(MenuOption.Exit);

    const CoinType coinType = CoinType.FiftyCent;
    const int coinQuantity = 2;
    _userInput.Setup(x => x.GetCoinType()).Returns(coinType);
    _userInput.Setup(x => x.GetCoinQuantity()).Returns(coinQuantity);

    var productName = It.IsAny<string>();
    _userInput.Setup(x => x.GetProductName()).Returns(productName);

    // Act
    await _sut.Run();

    // Assert
    switch (menuOption)
    {
      case MenuOption.InsertCoins:

        _commandBus.Verify(
          x => x.SendAsync<AcceptCoinCommand, Unit>(
            It.Is<AcceptCoinCommand>(y => y.CoinType == coinType && y.Quantity == coinQuantity)), Times.Once());
        break;
      case MenuOption.ReturnCoins:
        _commandBus.Verify(x => x.SendAsync<ReturnCoinsCommand, Unit>(It.IsAny<ReturnCoinsCommand>()), Times.Once());
        break;
      case MenuOption.BuyProduct:
        _commandBus.Verify(
          x => x.SendAsync<BuyProductCommand, Unit>(It.Is<BuyProductCommand>(x => x.ProductName == productName)),
          Times.Once());
        break;
      case MenuOption.ShowAvailableProducts:
        _commandBus.Verify(x => x.SendAsync<ShowAvailableProductsQuery, Unit>(It.IsAny<ShowAvailableProductsQuery>()),
          Times.Once());
        break;
      case MenuOption.ShowDepositedAmount:
        _commandBus.Verify(x => x.SendAsync<ShowDepositedAmountQuery, Unit>(It.IsAny<ShowDepositedAmountQuery>()),
          Times.Once());

        break;
      case MenuOption.Exit:
        _consoleWriter.Verify(x => x.ExitMessage(), Times.Once);
        break;
      default:
        throw new ArgumentOutOfRangeException(nameof(menuOption), menuOption, null);
    }
  }
}