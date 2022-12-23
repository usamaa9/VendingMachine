using System.ComponentModel;

namespace VendingMachine.Application.Enumerations;

public enum CoinType
{
    None,

    [Description("10c")]
    TenCent,

    [Description("20c")]
    TwentyCent,

    [Description("50c")]
    FiftyCent,

    [Description("1e")]
    OneEuro
}
