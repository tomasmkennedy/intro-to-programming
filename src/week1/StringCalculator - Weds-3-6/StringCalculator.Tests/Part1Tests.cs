
namespace StringCalculator.Tests;
public class Part1Tests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new Calculator();
        var result = calculator.Add("");
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("15", 15)]
    [InlineData("721", 721)]
    [InlineData("0", 0)]
    public void OneNumberStringReturnsSum(string numberString, int numberInt)
    {
        var calculator = new Calculator();

        var result = calculator.Add(numberString);

        Assert.Equal(numberInt, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("1,0", 1)]
    public void TwoNumberStringReturnsSum(string numberString, int numberInt)
    {
        var calculator = new Calculator();

        var result = calculator.Add(numberString);

        Assert.Equal(numberInt, result);
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("1,0,5,5", 11)]
    [InlineData("1,1,1,1,1,1,1", 7)]
    public void ManyNumberStringReturnsSum(string numberString, int numberInt)
    {
        var calculator = new Calculator();

        var result = calculator.Add(numberString);

        Assert.Equal(numberInt, result);
    }

    [Theory]
    [InlineData("1,2\n3", 6)]
    [InlineData("1\n0\n5\n5", 11)]
    [InlineData("1\n1,1,1,1\n1,1", 7)]
    public void ManyNumberStringWithNewlineReturnsSum(string numberString, int numberInt)
    {
        var calculator = new Calculator();

        var result = calculator.Add(numberString);

        Assert.Equal(numberInt, result);
    }

    [Theory]
    [InlineData("1,2\n,3")]
    [InlineData("1\n0\n5,\n5")]
    public void MultipleDelimitersInSuccessionThrowsException(string numberString)
    {
        var calculator = new Calculator();

        Assert.Throws<DelimiterFormatException>(() => calculator.Add(numberString));
    }

    [Theory]
    [InlineData("1,2\n\n,")]
    [InlineData("1,2,")]
    public void EndingDelimiterThrowsException(string numberString)
    {
        var calculator = new Calculator();

        Assert.Throws<DelimiterFormatException>(() => calculator.Add(numberString));
    }

    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//]\n1]3", 4)]
    public void CustomDelimiterReturnsSum(string numberString, int numberInt)
    {
        var calculator = new Calculator();

        var result = calculator.Add(numberString);

        Assert.Equal(numberInt, result);
    }
}
