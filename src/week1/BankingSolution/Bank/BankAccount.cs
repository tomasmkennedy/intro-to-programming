namespace Bank;


public enum AccountType { Standard, Gold };
public class BankAccount
{
    private decimal _currentBalance = 5000m;

    public virtual void Deposit(decimal amountToDeposit)
    {
        GuardTransactionAmount(amountToDeposit);
        _currentBalance = _currentBalance + amountToDeposit;
    }

    private static void GuardTransactionAmount(decimal amountToWithdraw)
    {
        if (amountToWithdraw <= 0)
        {
            throw new InvalidTransactionAmountException();
        }
    }

    public decimal GetBalance()
    {
        return _currentBalance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw >= _currentBalance)
        {
            throw new OverdraftException();
        }
        GuardTransactionAmount(amountToWithdraw);
        _currentBalance = _currentBalance - amountToWithdraw;
    }

    // Overloaded the Withdraw
    public void Withdraw(Money amountToWithdraw)
    {
        _currentBalance = _currentBalance - amountToWithdraw.Amount;
    }

    public class Money
    {
        public decimal Amount { get; private set; }
        public Currency Currency { get; private set; }
        private Money() { }
        public static Money FromUsd(decimal amount)
        {
            if (amount < 0)
            {
                throw new Exception();
            }
            return new Money { Amount = amount, Currency = Currency.USD };
        }
    }
    public enum Currency { USD, EUR, YEN }
}