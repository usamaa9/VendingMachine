using VendingMachine.App.Mediator;

namespace VendingMachine.App.UnitTests.Mediator;

public class CommandBusTests
{
    [Fact]
    public async Task SendAsync_SendsTheCommand_Success()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var command = new SampleCommand { TestField = "123" };
        mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(Unit.Value);

        var sut = new CommandBus(mediatorMock.Object);

        // Act
        var result = await sut.SendAsync<SampleCommand, Unit>(
            command);

        // Assert
        ((object)result).ShouldNotBeNull();
        mediatorMock.Verify(x => x.Send(command, default), Times.Once);
    }

    private class SampleCommand : IRequest<Unit>
    {
        public string TestField { get; init; } = null!;
    }
}
