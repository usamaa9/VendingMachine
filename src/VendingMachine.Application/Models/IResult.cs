namespace VendingMachine.Application.Models;

/// <summary>
/// Details of a Result.
/// </summary>
public interface IResult
{
  /// <summary>
  /// Stores any data required by the result.
  /// </summary>
  public object? CustomState { get; set; }

  /// <summary>
  /// Stores any message sent in the result.
  /// </summary>
  public string? Message { get; set; }
}