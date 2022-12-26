namespace VendingMachine.Application.Models;

public class Result<T> : Result
{
  public Result()
  {
  }

  public Result(string message) : base(message)
  {
  }

  /// <summary>
  /// Value.
  /// </summary>
  public T? Value { get; set; }
}