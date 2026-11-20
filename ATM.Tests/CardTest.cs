namespace ATM.ATM.Tests;

using Xunit;

public class CardTest
{
    Card card;

    public CardTest()
    {
        Account account = new Account (5000);
        card = new Card ("1234-5678", "1234", account);
    }

     [Theory]
    [InlineData("1234", true)]
    [InlineData("2345", false)]
    [InlineData("0123", false)]
    [InlineData("abcd", false)]
    [InlineData("12345", false)]
    [InlineData("123", false)]
    public void MatchesPinTest(string pinCode, bool expected)
    {
        // arrange: kortet (PIN 1234) skapas i konstruktorn
        // act
        bool actual = card.MatchesPin(pinCode);

        // assert
        Assert.Equal(expected, actual);

    }
}