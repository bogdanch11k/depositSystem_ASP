namespace DepositSystem.Core;

public static class DepositCalculator
{
    public static decimal CalculateEarnings(decimal amount, int months, decimal annualInterestRate = 10m)
    {
        if (amount <= 0) throw new ArgumentException("Сума має бути більшою за нуль.");
        if (months <= 0) throw new ArgumentException("Кількість місяців має бути більшою за нуль.");

        decimal earnings = amount * (annualInterestRate / 100m) * (months / 12m);
        return Math.Round(earnings, 2);
    }
}