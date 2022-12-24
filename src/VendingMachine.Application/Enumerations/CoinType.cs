using System.ComponentModel;

namespace VendingMachine.Application.Enumerations;

public enum CoinType
{
  None,

  [Description("10c")] TenCent = 10,

  [Description("20c")] TwentyCent = 20,

  [Description("50c")] FiftyCent = 50,

  [Description("1e")] OneEuro = 100
}