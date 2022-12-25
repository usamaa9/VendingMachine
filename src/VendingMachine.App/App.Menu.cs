using VendingMachine.App.IOHelpers;

namespace VendingMachine.App;

public partial class App
{
  private MenuOptions GetUserMenuChoice()
  {
    while (true)
    {
      _consolePrinter.AskUserForMenuChoice();

      var input = Console.ReadLine();
      if (int.TryParse(input, out var choice) && choice > 0 && choice <= Enum.GetValues(typeof(MenuOptions)).Length)
        return (MenuOptions)(choice - 1);

      _consolePrinter.InvalidMenuChoiceMessage();
    }
  }
}