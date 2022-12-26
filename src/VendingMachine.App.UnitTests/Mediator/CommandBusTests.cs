﻿namespace VendingMachine.App.UnitTests.Mediator;

public class CommandBusTests
{
  [Fact]
  public async Task SendAsync_SendsTheCommand_Success()
  {
    // Arrange
    var mediatorMock = new Mock<IMediator>();
    var command = new TestCommand();
    var mediatorResult = Result.From(Unit.Value);
    mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(mediatorResult);

    var sut = new CommandBus(mediatorMock.Object);

    // Act
    var result = await sut.SendAsync<TestCommand, Unit>(
      command);

    // Assert
    Assert.Equal(mediatorResult, result);
    mediatorMock.Verify(x => x.Send(command, default), Times.Once);
  }

  [Fact]
  public async Task PublishAsync_SendsNotification()
  {
    // Arrange
    var mediatorMock = new Mock<IMediator>();
    var notification = new TestNotification();
    mediatorMock.Setup(x => x.Publish(notification, default));

    var sut = new CommandBus(mediatorMock.Object);

    // Act
    await sut.PublishAsync(notification);

    // Assert
    mediatorMock.Verify(x => x.Publish(notification, default), Times.Once);
  }

  [ExcludeFromCodeCoverage]
  private class TestCommand : IRequest<Result<Unit>>
  {
  }

  private class TestNotification : INotification
  {
  }
}