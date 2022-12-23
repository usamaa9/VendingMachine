using MediatR;
using VendingMachine.Application.Enumerations;

namespace VendingMachine.Application.Features.Events;

public class AcceptedCoinEvent : INotification
{
    public CoinType CoinType { get; set; }

    public int Quantity { get; set; }
}
