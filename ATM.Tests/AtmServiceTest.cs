namespace ATM.ATM.Tests;

using Xunit;

public class AtmServiceTest
{
    Card card;
    AtmService atmService;
    public AtmServiceTest()
    {
        Account account = new Account (5000);
        card = new Card ("1234-5678", "1234", account);
        atmService = new AtmService (7000);
    }

    [Fact]
    public void InsertCardTest()
    {
        // arrange: kort, konto och atm-innehav skapas i konstruktorn.

        // act
        atmService.InsertCard(card);

        // assert
        Assert.True(atmService.HasCardInserted);
    }

    [Theory]
    [InlineData("1234", true)]
    [InlineData("2345", false)]
    [InlineData("abcd", false)]
    [InlineData("12345", false)]
    [InlineData("123", false)]
    public void EnterPinTest(string pin, bool expected)
    {
        // arrange: kort, konto och atm-innehav skapas i konstruktorn.
        atmService.InsertCard(card);

        // act
        bool actual = atmService.EnterPin(pin);

        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EjectCardTest()
    {
        // arrange
        atmService.InsertCard(card);
        atmService.EnterPin("1234");
        
        // act
        atmService.EjectCard();

        // assert
        Assert.False(atmService.HasCardInserted);
        Assert.False(atmService.IsAuthenticated);
    }

}