using VendingMachine.ConsoleApp.IOHelpers;

namespace VendingMachine.ConsoleApp.UnitTests.IOHelpers;

public class UserInputTests
{
  private readonly Mock<IConsoleReader> _consoleReader;
  private readonly Mock<IConsoleWriter> _consoleWriter;
  private readonly UserInput _sut;

  public UserInputTests()
  {
    _consoleReader = new Mock<IConsoleReader>();
    _consoleWriter = new Mock<IConsoleWriter>();
    _sut = new UserInput(_consoleWriter.Object, _consoleReader.Object);
  }

  [Fact]
  public void GetCoinType_ReturnsExpectedCoinType()
  {
    // Arrange
    _consoleReader.Setup(x => x.ReadLine()).Returns("20c");

    // Act
    var result = _sut.GetCoinType();

    // Assert
    result.ShouldBe(CoinType.TwentyCent);
  }

  [Fact]
  public void GetCoinType_InvalidCoinType_DisplaysErrorMessage()
  {
    // Arrange
    _consoleReader.SetupSequence(x => x.ReadLine()).Returns("2").Returns("20c");
    // Act
    var result = _sut.GetCoinType();

    // Assert
    _consoleWriter.Verify(x => x.InvalidCoinTypeMessage(), Times.Once);
    result.ShouldBe(CoinType.TwentyCent);
  }

  [Fact]
  public void GetCoinQuantity_ReturnsExpectedCoinQuantity()
  {
    // Arrange
    _consoleReader.Setup(x => x.ReadLine()).Returns("5");

    // Act
    var result = _sut.GetCoinQuantity();

    // Assert
    result.ShouldBe(5);
  }

  [Fact]
  public void GetCoinQuantity_InvalidCoinQuantity_DisplaysErrorMessage()
  {
    // Arrange
    _consoleReader.SetupSequence(x => x.ReadLine()).Returns("a").Returns("-1").Returns("5");

    // Act
    var result = _sut.GetCoinQuantity();

    // Assert
    _consoleWriter.Verify(x => x.InvalidCoinQuantityMessage(), Times.Exactly(2));
    result.ShouldBe(5);
  }

  [Fact]
  public void GetUserMenuChoice_ReturnsExpectedMenuOption()
  {
    // Arrange
    _consoleReader.Setup(x => x.ReadLine()).Returns("1");

    // Act
    var result = _sut.GetUserMenuChoice();

    // Assert
    result.ShouldBe(MenuOptions.InsertCoins);
  }

  [Fact]
  public void GetUserMenuChoice_InvalidChoice_DisplaysErrorMessage()
  {
    // Arrange
    _consoleReader.SetupSequence(x => x.ReadLine()).Returns("-1").Returns("1");

    // Act
    var result = _sut.GetUserMenuChoice();

    // Assert
    _consoleWriter.Verify(x => x.InvalidMenuChoiceMessage(), Times.Exactly(1));
    result.ShouldBe(MenuOptions.InsertCoins);
  }

  [Fact]
  public void GetProductName_ReturnsExpectedProductName()
  {
    // Arrange
    _consoleReader.Setup(x => x.ReadLine()).Returns(It.IsAny<string>());

    // Act
    var result = _sut.GetProductName();

    // Assert
    result.ShouldBe(It.IsAny<string>());
  }
}