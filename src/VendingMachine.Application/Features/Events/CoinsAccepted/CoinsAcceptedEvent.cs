namespace VendingMachine.Application.Features.Events.CoinsAccepted;

public class CoinsAcceptedEvent : INotification
{
  public CoinType CoinType { get; set; }

  public int Quantity { get; set; }
}