namespace CSharpSyntax;
public class BankAccount
{
    protected decimal _balance = 0;
    public int Id { get; set; }

    public virtual void Deposit(decimal amount)
    {
        _balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        _balance -= amount;
    }
    public decimal GetCurrentBalance()
    {
        return _balance;
    }
}

public class GoldAccount : BankAccount
{
    public override void Deposit(decimal amount)
    {
        base.Deposit(amount * 1.10M);
    }

    public bool HasLotsOfMoney()
    {
        return _balance > 1000;
    }
}