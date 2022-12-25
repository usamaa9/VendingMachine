using MediatR;
using VendingMachine.Application.Enumerations;

namespace VendingMachine.Application.Features.Events;

/// <summary>
/// Event for when a product is bought.
/// </summary>
public class ProductBoughtEvent : INotification
{
  public string? ProductName { get; set; }
  public Dictionary<CoinType, int>? UserCoins { get; set; }
  public Dictionary<CoinType, int>? ChangeCoins { get; set; }
}