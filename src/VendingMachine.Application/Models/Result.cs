namespace VendingMachine.Application.Models;

public class Result : IResult
{
  /// <summary>
  /// Initializes a new instance of the <see cref="Result"/> class.
  /// </summary>
  public Result()
  {
  }

  public Result(string message)
  {
    Message = message;
  }

  public string? Message { get; set; }

  public object? CustomState { get; set; }

  /// <summary>
  /// Method for generating a result.
  /// </summary>
  /// <typeparam name="T">type of result.</typeparam>
  /// <param name="value"></param>
  /// <returns></returns>
  public static Result<T> From<T>(T value)
  {
    return new Result<T> { Value = value };
  }
}