using Bank;

namespace Banking.UnitTests.Accounts;
public class GoldCustomerDeposits
{
    [Theory]
    [InlineData(100, 110)]
    [InlineData(42.23, 46.453)]
    public void MakingADespositIncreasesBalance(decimal amountToDeposit, decimal expected)
    {
        // Given
        var account = new GoldAccount();
        // Get Balance is a "Query" - we are asking it for something.
        var openingBalance = account.GetBalance();

        // When
        // WTCYWYH 
        // Command - Telling it to do some work.
        account.Deposit(amountToDeposit);

        // Then
        Assert.Equal(openingBalance + expected, account.GetBalance());
    }
}
