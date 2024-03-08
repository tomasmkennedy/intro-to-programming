
// https://osherove.com/tdd-kata-1
global using NSubstitute;

namespace StringCalculator.Tests;
public class Part1Tests
{
    private Calculator calculator = new Calculator(Substitute.For<ILogger>(), Substitute.For<IWebService>());
    [Fact]
    public void EmptyStringReturnsZero()
    {


        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    public void SingleDigits(string numbers, int expected)
    {

        var results = calculator.Add(numbers);

        Assert.Equal(expected, results);
    }

    // skip some of these
    [Theory]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]

    public void Arbitrary(string numbers, int expected)
    {

        var results = calculator.Add(numbers);

        Assert.Equal(expected, results);
    }
}
