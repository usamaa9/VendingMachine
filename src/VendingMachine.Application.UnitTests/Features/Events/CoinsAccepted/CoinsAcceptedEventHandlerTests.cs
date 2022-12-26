using VendingMachine.Application.Features.Events.CoinsAccepted;

namespace VendingMachine.Application.UnitTests.Features.Events.CoinsAccepted;

public class CoinsAcceptedEventHandlerTests
{
  private readonly CoinsAcceptedEventHandler _handler;
  private readonly Mock<IConsoleWriter> _mockConsolePrinter;
  private readonly CoinsAcceptedEvent _validEvent;

  public CoinsAcceptedEventHandlerTests()
  {
    _mockConsolePrinter = new Mock<IConsoleWriter>();
    _handler = new CoinsAcceptedEventHandler(_mockConsolePrinter.Object);
    _validEvent = new CoinsAcceptedEvent
    {
      CoinType = CoinType.OneEuro,
      Quantity = 2
    };
  }

  [Fact]
  public async void Handle_DisplaysCoinsAcceptedMessage()
  {
    // Act
    await _handler.Handle(_validEvent, CancellationToken.None);

    // Assert
    _mockConsolePrinter.Verify(
      x => x.DisplayMessage(It.Is<string>(
        message => message.Contains("Coins have been accepted"))),
      Times.Once());
  }
}