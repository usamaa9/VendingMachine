namespace VendingMachine.ConsoleApp.IOHelpers;

[ExcludeFromCodeCoverage]
public class ConsoleReader : IConsoleReader
{
  public string? ReadLine()
  {
    return Console.ReadLine();
  }
}