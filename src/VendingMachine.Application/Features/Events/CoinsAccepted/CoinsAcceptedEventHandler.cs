using MediatR;
using VendingMachine.Application.IOHelpers;

namespace VendingMachine.Application.Features.Events.CoinsAccepted;

public class CoinsAcceptedEventHandler : INotificationHandler<CoinsAcceptedEvent>
{
  private readonly IConsolePrinter _consolePrinter;

  public CoinsAcceptedEventHandler(IConsolePrinter consolePrinter)
  {
    _consolePrinter = consolePrinter;
  }

  public Task Handle(CoinsAcceptedEvent notification, CancellationToken cancellationToken)
  {
    _consolePrinter.DisplayMessage("Coins Have been accepted.");
    return Task.CompletedTask;
  }
}