namespace VendingMachine.Application.Entities;

public class VendingMachineProduct
{
  public string? Name { get; set; }

  public decimal Price { get; set; }

  public int Portions { get; set; }
}