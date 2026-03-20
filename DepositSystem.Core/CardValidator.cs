namespace DepositSystem.Core;

public static class CardValidator
{
    public static bool IsValid(string cardNumber)
    {
        if (string.IsNullOrWhiteSpace(cardNumber) || cardNumber.Length < 13 || cardNumber.Length > 19)
            return false;

        if (!cardNumber.All(char.IsDigit))
            return false;

        int sum = 0;
        bool alternate = false;
        
        for (int i = cardNumber.Length - 1; i >= 0; i--)
        {
            int n = cardNumber[i] - '0';

            if (alternate)
            {
                n *= 2;
                if (n > 9) n -= 9;
            }

            sum += n;
            alternate = !alternate;
        }

        return sum % 10 == 0;
    }
}