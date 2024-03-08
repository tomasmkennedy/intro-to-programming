using CSharpSyntax.Extensions;

namespace CSharpSyntax;
public class ValuesAndReferences
{
    [Fact]
    public void EntityAndValueDemo()
    {
        decimal myMoney = 5.00M;
        Decimal yourMoney = 5.00M;

        var myAccount = new BankAccount()
        {
            Id = 52
        };

        var yourAccount = new BankAccount();
        yourAccount.Id = 82;

        yourAccount.Deposit(1000);

        myAccount.Withdraw(800);

    }

    [Fact]
    public void UsingAService()
    {
        var manager = new AccountManager();
        manager.DepositIntoAccount(52, 1000000);
        System.Int32 x = 10;

        Assert.True(x.IsEven());

        var sunday = 3.DaysFromToday();

        var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


        var evens = numbers.Where(n => n.IsEven());


        // "Homoiconicity"
        //var accounts = context
        //    .BankAccounts
        //    .Where(a => a.GetBalance() > 1000)
        //    .OrderBy(a => a.Id).ToList();

        //Assert.True(Utils.IsEven(4));
        //Assert.False(Utils.IsEven(5));
    }

}
