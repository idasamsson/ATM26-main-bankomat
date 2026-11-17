namespace ATM.ATM.Tests;

using Xunit;

public class AtmServiceTest
{
    Card card;
    AtmService atmService;
    void setupService()
    {
        Account account = new Account (5000);
        card = new Card ("1234-5678", "1234", account);
        atmService = new AtmService (5000);
    }

    [Fact]
    public void InsertCardTest()
    {
        // setup
        Account account = new Account (5000);
        Card card = new Card ("1234-5678", "1234", account);
        AtmService atmService = new AtmService (5000);

        // test
        atmService.InsertCard(card);
        Assert.True(atmService.HasCardInserted);
    }

    [Theory]
    [InlineData("1234", true)]
    [InlineData("0123", false)]
    [InlineData("abcd", false)]
    [InlineData("12345", false)]
    [InlineData("123", false)]
    public void EnterPinTest(string pin, bool expected)
    {
        // setup
        setupService();
        atmService.InsertCard(card);

        // test
        bool actual = atmService.EnterPin(pin);
        Assert.Equal(expected, actual);
    }
}