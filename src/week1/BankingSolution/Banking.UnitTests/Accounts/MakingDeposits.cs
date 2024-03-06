using Bank;

namespace Banking.UnitTests.Accounts;
public class MakingDeposits
{
    [Theory]
    [InlineData(100)]
    public void MakingADespositIncreasesBalance(decimal amountToDeposit)
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        // WTCYWYH
        account.Deposit(amountToDeposit);

        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
    }

}
