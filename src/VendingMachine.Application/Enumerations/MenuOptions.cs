namespace VendingMachine.Application.Enumerations;

public enum MenuOption
{
  [Description("Insert coins")] InsertCoins,
  [Description("Return coins")] ReturnCoins,
  [Description("Buy a product")] BuyProduct,

  [Description("Show available products")]
  ShowAvailableProducts,
  [Description("Show deposited amount")] ShowDepositedAmount,
  [Description("Exit")] Exit
}