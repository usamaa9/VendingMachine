using VendingMachine.Application.Features.Commands.ReturnCoins;

namespace VendingMachine.Application.UnitTests.Features.Commands.ReturnCoins;

public class ReturnCoinsCommandHandlerTests
{
  private readonly ReturnCoinsCommandHandler _handler;
  private readonly Mock<IConsoleWriter> _mockConsolePrinter;
  private readonly Mock<IUserWallet> _mockUserWallet;
  private readonly ReturnCoinsCommand _validCommand;

  public ReturnCoinsCommandHandlerTests()
  {
    _mockConsolePrinter = new Mock<IConsoleWriter>();
    _mockUserWallet = new Mock<IUserWallet>();
    _handler = new ReturnCoinsCommandHandler(
      _mockUserWallet.Object, _mockConsolePrinter.Object);
    _validCommand = new ReturnCoinsCommand();
  }

  [Fact]
  public async void Handle_RemovesAllCoinsFromUserWallet()
  {
    // Act
    await _handler.Handle(_validCommand, CancellationToken.None);

    // Assert
    _mockUserWallet.Verify(x => x.RemoveAllCoins(), Times.Once());
    _mockConsolePrinter.Verify(x => x.ReturnedCoinsMessage(), Times.Once());
  }
}