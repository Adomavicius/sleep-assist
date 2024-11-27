using FluentAssertions;
using SleepAssist.Domain.ValueObjects;

namespace SleepAssist.Domain.UnitTests;

public class PercentageTests
{
    [TestCase(0.75, "75.00%")]
    [TestCase(0.12345, "12.35%")]
    [TestCase(0.01234, "1.23%")]
    [TestCase(1.123, "112.30%")]
    public void Percentage_Correctly_Formats(decimal number, string expectedString)
    {
        new Percentage(number).ToString().Should().Be(expectedString);
    }

    [TestCase(1.12345, 0, "100.00%")]
    [TestCase(1.12345, 1, "110.00%")]
    [TestCase(1.12345, 2, "112.00%")]
    [TestCase(1.12345, 3, "112.30%")]
    [TestCase(1.12345, 4, "112.34%")]
    [TestCase(1.12345, 5, "112.35%")]
    public void Percentage_Correctly_Formats_With_Precision(decimal number, int precision, string expectedString)
    {
        new Percentage(number).GetRounded(precision).ToString().Should().Be(expectedString);
    }
}