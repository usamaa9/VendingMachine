namespace VendingMachine.Application.Features.Events.CoinsAccepted;

public class CoinsAcceptedEventHandler : INotificationHandler<CoinsAcceptedEvent>
{
  private readonly IConsoleWriter _consoleWriter;

  public CoinsAcceptedEventHandler(IConsoleWriter consoleWriter)
  {
    _consoleWriter = consoleWriter;
  }

  public Task Handle(CoinsAcceptedEvent notification, CancellationToken cancellationToken)
  {
    _consoleWriter.DisplayMessage("Coins have been accepted.");
    return Task.CompletedTask;
  }
}