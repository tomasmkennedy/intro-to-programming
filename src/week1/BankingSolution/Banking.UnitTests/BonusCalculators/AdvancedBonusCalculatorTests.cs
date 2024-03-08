using Bank;
using NSubstitute;

namespace Banking.UnitTests.BonusCalculators;
public class AdvancedBonusCalculatorTests
{
    [Fact]
    public void DuringBusinessHours()
    {
        var stubbedClock = Substitute.For<IProvideTheBusinessClock>();
        stubbedClock.IsOpen().Returns(true);
        var calcuator = new AdvancedBonusCalculator(stubbedClock);

        var bonus = calcuator.CalculateDepositBonusFor(5000, 100);

        Assert.Equal(10, bonus);
    }
    [Fact]
    public void WhenWeAreClosed()
    {

        var stubbedClock = Substitute.For<IProvideTheBusinessClock>();
        stubbedClock.IsOpen().Returns(true);
        var calcuator = new AdvancedBonusCalculator(stubbedClock);

        var bonus = calcuator.CalculateDepositBonusFor(5000, 100);

        Assert.Equal(0, bonus);
    }
}