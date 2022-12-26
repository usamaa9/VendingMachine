using VendingMachine.Application.Features.Events.CoinsAccepted;

namespace VendingMachine.Application.UnitTests.Features.Events.CoinsAccepted;

public class CoinsAcceptedEventHandlerTests
{
  private readonly Mock<IConsoleWriter> _consoleWriter;
  private readonly CoinsAcceptedEventHandler _handler;
  private readonly CoinsAcceptedEvent _validEvent;

  public CoinsAcceptedEventHandlerTests()
  {
    _consoleWriter = new Mock<IConsoleWriter>();
    _handler = new CoinsAcceptedEventHandler(_consoleWriter.Object);
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
    _consoleWriter.Verify(
      x => x.DisplayMessage(It.Is<string>(
        message => message.Contains("Coins have been accepted"))),
      Times.Once());
  }
}