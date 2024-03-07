namespace Bank;
public class GoldAccount : BankAccount
{
    public override void Deposit(decimal amountToDeposit)
    {
        base.Deposit(amountToDeposit * 1.10M);
    }
}

public class PlatinumAccount : BankAccount
{
    public override void Deposit(decimal amountToDeposit)
    {
        base.Deposit(amountToDeposit * 1.25M);
    }
}
