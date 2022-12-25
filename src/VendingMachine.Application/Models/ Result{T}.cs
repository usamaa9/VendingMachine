namespace VendingMachine.Application.Models;

public class Result<T> : Result
{
  /// <summary>
  /// Value.
  /// </summary>
  public T? Value { get; set; }
}