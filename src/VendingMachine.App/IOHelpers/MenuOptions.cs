using System.ComponentModel;

namespace VendingMachine.App.IOHelpers;

public enum MenuOptions
{
  [Description("Insert coins")] InsertCoins,
  [Description("Return coins")] ReturnCoins,
  [Description("Buy a product")] BuyProduct,

  [Description("Show available products")]
  ShowAvailableProducts,
  [Description("Show deposited amount")] ShowDepositedAmount,
  [Description("Exit")] Exit
}