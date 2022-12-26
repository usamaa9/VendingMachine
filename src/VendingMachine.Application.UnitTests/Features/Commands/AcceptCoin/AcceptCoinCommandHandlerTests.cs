using VendingMachine.Application.Features.Commands.AcceptCoin;
using VendingMachine.Application.Features.Events.CoinsAccepted;

namespace VendingMachine.Application.UnitTests.Features.Commands.AcceptCoin;

public class AcceptCoinCommandHandlerTests
{
  private readonly Mock<ICommandBus> _commandBus;
  private readonly AcceptCoinCommandHandler _handler;
  private readonly Mock<IUserWallet> _userWallet;
  private readonly AcceptCoinCommand _validCommand;

  public AcceptCoinCommandHandlerTests()
  {
    _userWallet = new Mock<IUserWallet>();
    _commandBus = new Mock<ICommandBus>();
    _handler = new AcceptCoinCommandHandler(_userWallet.Object, _commandBus.Object);
    _validCommand = new AcceptCoinCommand
    {
      CoinType = CoinType.FiftyCent,
      Quantity = 3
    };
  }

  [Fact]
  public async void Handle_AddsCoinsToUserWallet()
  {
    // Act
    await _handler.Handle(_validCommand, CancellationToken.None);

    // Assert
    _userWallet.Verify(x => x.AddCoins(_validCommand.CoinType, _validCommand.Quantity), Times.Once());
  }

  [Fact]
  public async void Handle_PublishesCoinsAcceptedEvent()
  {
    // Act
    await _handler.Handle(_validCommand, CancellationToken.None);

    // Assert
    _commandBus.Verify(
      x => x.PublishAsync(It.Is<CoinsAcceptedEvent>(
        e => e.CoinType == _validCommand.CoinType && e.Quantity == _validCommand.Quantity)),
      Times.Once());
  }
}