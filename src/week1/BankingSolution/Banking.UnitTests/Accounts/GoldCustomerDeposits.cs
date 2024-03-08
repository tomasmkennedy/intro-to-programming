using Bank;

namespace Banking.UnitTests.Accounts;
public class GoldCustomerDeposits
{
    [Fact]
    public void MakingADespositIncreasesBalance()
    {
        // Given
        var account = new BankAccount(new StubbedBonusCalculator());
        // Get Balance is a "Query" - we are asking it for something.
        var openingBalance = account.GetBalance();

        // When
        // WTCYWYH 
        // Command - Telling it to do some work.
        account.Deposit(142.23M);

        // Then
        //Assert.Equal(openingBalance + expected, account.GetBalance());
        // did the bonus calculator get called with the balance, and the amount to deposit.
        // did the bonus get added to the balance.

        Assert.Equal(openingBalance + 142.23M + 13.23M, account.GetBalance());
    }
}
