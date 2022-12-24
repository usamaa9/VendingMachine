using MediatR;

namespace VendingMachine.Application.Features.Events;

public class ProductBoughtEvent : INotification
{
  public string? ProductName { get; set; }
  public decimal Price { get; set; }
}