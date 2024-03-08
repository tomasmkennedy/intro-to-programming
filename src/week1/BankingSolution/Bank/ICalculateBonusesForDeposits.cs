namespace Bank;

public interface ICalculateBonusesForDeposits
{
    public decimal CalculateDepositBonusFor(decimal currentBalance, decimal amountToDeposit);
}