using TechnologyOneAssignment.Services;

namespace TechnologyOneAssignment.Tests;

public class NumberService_ConvertDoubleToStringOfDollarsAndCentsShould
{
    private NumberService _numberService;

    public NumberService_ConvertDoubleToStringOfDollarsAndCentsShould()
    {
        _numberService = new NumberService();
    }

    [Theory]
    [InlineData(123.45, "one hundred twenty-three dollars fourty-five cents")]
    [InlineData(2123.45, "two thousand one hundred twenty-three dollars fourty-five cents")]
    [InlineData(999999999999.91, "nine hundred ninety-nine billion nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars ninety-one cents")]
    public void ConvertDoubleToStringOfDollarsAndCents_ValuesWithDollarsAndCents_ShouldIncludeDollarsAndCents(decimal number, string expected)
    {
        string result = _numberService.ConvertDoubleToStringOfDollarsAndCents(number);
        Assert.Equal(expected, result);

    }

    [Theory]
    [InlineData(123.00, "one hundred twenty-three dollars")]
    [InlineData(123, "one hundred twenty-three dollars")]
    public void ConvertDoubleToStringOfDollarsAndCents_ValuesWithDollars_ShouldNotIncludeCents(decimal number, string expected)
    {
        string result = _numberService.ConvertDoubleToStringOfDollarsAndCents(number);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(42000001.11, "fourty-two million one dollars eleven cents")]
    [InlineData(100000000000.12, "one hundred billion dollars twelve cents")]
    [InlineData(100000000.13, "one hundred million dollars thirteen cents")]
    public void ConvertDoubleToStringOfDollarsAndCents_ValuesWithoutCertainPlaceValues_ShouldNotPrintThosePlaceValues(decimal number, string expected)
    {
        string result = _numberService.ConvertDoubleToStringOfDollarsAndCents(number);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0.39, "thirty-nine cents")]
    [InlineData(.99, "ninety-nine cents")]
    [InlineData(0.09, "nine cents")]
    [InlineData(0.10, "ten cents")]
    [InlineData(00000000000.20, "twenty cents")]
    public void ConvertDoubleToStringOfDollarsAndCents_ValuesOfOnlyCents_ShouldOnlyPrintCents(decimal number, string expected)
    {
        string result = _numberService.ConvertDoubleToStringOfDollarsAndCents(number);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, "zero dollars")]
    [InlineData(0.00, "zero dollars")]
    public void ConvertDoubleToStringOfDollarsAndCents_ValuesOfZero_ShouldPrintZeroDollars(decimal number, string expected)
    {
        string result = _numberService.ConvertDoubleToStringOfDollarsAndCents(number);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(-1.0, "number out of range (must be between 0 and 1,000,000,000,000)")]
    [InlineData(-1.45, "number out of range (must be between 0 and 1,000,000,000,000)")]
    [InlineData(99999999999999, "number out of range (must be between 0 and 1,000,000,000,000)")]
    public void ConvertDoubleToStringOfDollarsAndCents_ValuesOutOfRange_ShouldReturnErrorMessage(decimal number, string expected)
    {
        string result = _numberService.ConvertDoubleToStringOfDollarsAndCents(number);
        Assert.Equal(expected, result);
    }
}
    