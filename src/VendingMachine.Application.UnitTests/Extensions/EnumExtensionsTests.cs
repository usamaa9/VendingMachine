namespace VendingMachine.Application.UnitTests.Extensions;

public class EnumExtensionsTests
{
  public enum TestEnum
  {
    [Description("Value 1 Description")] Value1,

    [Description("Value 2 Description")] Value2,

    Value3
  }

  [Theory]
  [InlineData(TestEnum.Value1, "Value 1 Description")]
  [InlineData(TestEnum.Value2, "Value 2 Description")]
  [InlineData(TestEnum.Value3, "Value3")]
  public void GetDescription_ReturnsExpectedDescription(TestEnum value, string expected)
  {
    // Act
    var result = value.GetDescription();

    // Assert
    Assert.Equal(expected, result);
  }
}