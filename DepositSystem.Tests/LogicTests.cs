using DepositSystem.Core;
using NUnit.Framework;

namespace DepositSystem.Tests;

[TestFixture]
public class LogicTests
{
    [TestCase("4532015112830364", true)]
    [TestCase("4532015112830365", false)]
    [TestCase("123", false)]
    [TestCase("4532abcd12830364", false)]
    public void CardValidator_ShouldReturnCorrectResult(string cardNumber, bool expected)
    {
        var result = CardValidator.IsValid(cardNumber);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void DepositCalculator_ShouldCalculateCorrectly()
    {
        decimal earnings = DepositCalculator.CalculateEarnings(1000m, 6, 10m);
        Assert.That(earnings, Is.EqualTo(50m));
    }

    [Test]
    public void DepositCalculator_NegativeAmount_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => DepositCalculator.CalculateEarnings(-100m, 6));
    }
}