using Moq;
using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Features.Commands.AcceptCoin;
using VendingMachine.Application.Features.Events.CoinsAccepted;
using VendingMachine.Application.Mediator;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.UnitTests.Features.Commands.AcceptCoin;

public class AcceptCoinCommandHandlerTests
{
  private readonly AcceptCoinCommandHandler _handler;
  private readonly Mock<ICommandBus> _mockCommandBus;
  private readonly Mock<IUserWallet> _mockUserWallet;
  private readonly AcceptCoinCommand _validCommand;

  public AcceptCoinCommandHandlerTests()
  {
    _mockUserWallet = new Mock<IUserWallet>();
    _mockCommandBus = new Mock<ICommandBus>();
    _handler = new AcceptCoinCommandHandler(_mockUserWallet.Object, _mockCommandBus.Object);
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
    _mockUserWallet.Verify(x => x.AddCoins(_validCommand.CoinType, _validCommand.Quantity), Times.Once());
  }

  [Fact]
  public async void Handle_PublishesCoinsAcceptedEvent()
  {
    // Act
    await _handler.Handle(_validCommand, CancellationToken.None);

    // Assert
    _mockCommandBus.Verify(
      x => x.PublishAsync(It.Is<CoinsAcceptedEvent>(
        e => e.CoinType == _validCommand.CoinType && e.Quantity == _validCommand.Quantity)),
      Times.Once());
  }
}