using VendingMachine.Application.Features.Commands.ReturnCoins;

namespace VendingMachine.Application.UnitTests.Features.Commands.ReturnCoins;

public class ReturnCoinsCommandHandlerTests
{
  private readonly Mock<IConsoleWriter> _consolePrinter;
  private readonly ReturnCoinsCommandHandler _handler;
  private readonly Mock<IUserWallet> _userWallet;
  private readonly ReturnCoinsCommand _validCommand;

  public ReturnCoinsCommandHandlerTests()
  {
    _consolePrinter = new Mock<IConsoleWriter>();
    _userWallet = new Mock<IUserWallet>();
    _handler = new ReturnCoinsCommandHandler(
      _userWallet.Object, _consolePrinter.Object);
    _validCommand = new ReturnCoinsCommand();
  }

  [Fact]
  public async void Handle_RemovesAllCoinsFromUserWallet()
  {
    // Act
    await _handler.Handle(_validCommand, CancellationToken.None);

    // Assert
    _userWallet.Verify(x => x.RemoveAllCoins(), Times.Once());
    _consolePrinter.Verify(x => x.ReturnedCoinsMessage(), Times.Once());
  }
}