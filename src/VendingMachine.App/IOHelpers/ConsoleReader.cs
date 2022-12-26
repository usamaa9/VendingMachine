namespace VendingMachine.App.IOHelpers;

[ExcludeFromCodeCoverage]
public class ConsoleReader : IConsoleReader
{
  public string? ReadLine()
  {
    return Console.ReadLine();
  }
}