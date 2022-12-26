using VendingMachine.Application.Mediator;
using VendingMachine.ConsoleApp.Main;

namespace VendingMachine.ConsoleApp.UnitTests.ConsoleApp;

public partial class AppTests
{
  private readonly Mock<ICommandBus> _commandBus;
  private readonly Mock<IConsoleWriter> _consoleWriter;

  private readonly App _sut;
  private readonly Mock<IUserInput> _userInput;

  public AppTests()
  {
    _commandBus = new Mock<ICommandBus>();
    _consoleWriter = new Mock<IConsoleWriter>();
    _userInput = new Mock<IUserInput>();
  }
}