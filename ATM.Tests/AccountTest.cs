namespace ATM.ATM.Tests;

using Xunit;

public class AccountTest
{

    Account setupAccount(int balance)
    {
        int accountBalance = balance;
        Account account = new Account(accountBalance);
        return account;
    }
    [Fact]
    public void IsAccountTest()
    {
        int accountBalance = 5000;
        Account account = new Account(accountBalance);
        Assert.IsType<Account>(account);
        Assert.Equal(accountBalance, account.Balance);
    }

    [Fact]
    public void WithdrawTest()
    {
        // setup
        // int accountBalance = 5000;
        // Account account = new Account(accountBalance);

        Account account = setupAccount(5000);

        // test
        int withdrawal = 1000;
        account.Withdraw(withdrawal);
        int expectedBalance = 4000;
        Assert.Equal(expectedBalance, account.Balance);
    }

        [Fact]
    public void WithdrawNotNegativeTest()
    {
        // setup
        //  int accountBalance = 1000;
        // Account account = new Account(accountBalance);

        Account account = setupAccount(1000);

        // test
        int withdrawal = 2000;
        account.Withdraw(withdrawal);
        int expectedBalance = 1000;
        Assert.Equal(expectedBalance, account.Balance);
    }
}
