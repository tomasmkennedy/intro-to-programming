namespace Bank;
public class AdvancedBonusCalculator(IProvideTheBusinessClock clock) : ICalculateBonusesForDeposits
{
    public decimal CalculateDepositBonusFor(decimal currentBalance, decimal amountToDeposit)
    {
        // If it is between 9AM and 5PM, not on a weekend, not on a holiday, then
        // if the currentBalance >= 5000 return a bonus of 10 percent,
        // otherwise return nothing.
        if (clock.IsOpen() && currentBalance >= 5000M)
        {
            return amountToDeposit * .10M;
        }
        return 0;
    }
}
