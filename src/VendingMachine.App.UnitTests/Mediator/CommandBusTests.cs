namespace VendingMachine.App.UnitTests.Mediator;

public class CommandBusTests
{
  [Fact]
  public async Task SendAsync_SendsTheCommand_Success()
  {
    // Arrange
    var mediatorMock = new Mock<IMediator>();
    var command = new SampleCommand();
    mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(Result.From(Unit.Value));

    var sut = new CommandBus(mediatorMock.Object);

    // Act
    var result = await sut.SendAsync<SampleCommand, Unit>(
      command);

    // Assert
    ((object)result).ShouldNotBeNull();
    mediatorMock.Verify(x => x.Send(command, default), Times.Once);
  }

  [ExcludeFromCodeCoverage]
  private class SampleCommand : IRequest<Result<Unit>>
  {
  }
}