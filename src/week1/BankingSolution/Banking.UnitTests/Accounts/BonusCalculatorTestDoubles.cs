using Bank;

namespace Banking.UnitTests.Accounts;

public class DummyBonusCalculator : ICalculateBonusesForDeposits
{
    public decimal CalculateDepositBonusFor(decimal currentBalance, decimal amountToDeposit)
    {
        return 0;
    }
}

public class StubbedBonusCalculator : ICalculateBonusesForDeposits
{
    public decimal CalculateDepositBonusFor(decimal currentBalance, decimal amountToDeposit)
    {
        return currentBalance == 5000M && amountToDeposit == 142.23M ? 13.23M : 0;
    }
}