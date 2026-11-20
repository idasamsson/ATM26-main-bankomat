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
        //Assert.IsType<Account>(account);
        Assert.Equal(accountBalance, account.Balance);
    }

    [Theory]
    [InlineData(1000, 4000)]
    [InlineData(5000, 0)]
    [InlineData(1, 4999)]
    public void WithdrawTest(int withdrawal, int expectedBalance)
    {
        // arrange
        Account account = setupAccount(5000);

        // act
       bool actual = account.Withdraw(withdrawal);

        // assert
        Assert.True(actual);
        Assert.Equal(expectedBalance, account.Balance);
    }

        [Fact]
    public void WithdrawExceedsBalanceTest()
    {
        // arrange
        Account account = setupAccount(1000);
        int withdrawal = 2000;
        int expectedBalance = 1000;

        // act
        bool actual = account.Withdraw(withdrawal);

        // assert
        Assert.False(actual);
        Assert.Equal(expectedBalance, account.Balance);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-500)]
    public void WithdrawInvalidAmountTest(int withdrawal)
    {
        // arrange
        Account account = setupAccount(5000);
        int expectedBalance = 5000;

        // act
        bool actual = account.Withdraw(withdrawal);

        // assert
        Assert.False(actual);
        Assert.Equal(expectedBalance, account.Balance);
    }

    [Theory]
    [InlineData(500, 5500)]
    [InlineData(1, 5001)]
    [InlineData(5000, 10000)]


    public void DepositTest(int deposit, int expectedBalance)
    {
        // arrange
        Account account = setupAccount(5000);

        // act
       bool actual = account.Deposit(deposit);

        // assert
        Assert.True(actual);
        Assert.Equal(expectedBalance, account.Balance);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-500)]

    public void DepositInvalidAmountTest(int deposit)
    {
        // arrange
        Account account = setupAccount(5000);
        int expectedBalance = 5000;

        // act
        bool actual = account.Deposit(deposit);

        // assert
        Assert.False(actual);
        Assert.Equal(expectedBalance, account.Balance);
    }
}
